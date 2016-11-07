using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Serialization;
using Insurance.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CalculateIntegrationMonitor
{
    public class CalculateIntegrationService : ICalculateIntegrationService
    {

        private ICalculateIntegrationRepository repository;
        private IQuotationRepository quotationRepository;
        private IEstimateRepository estimateRepository;

        public CalculateIntegrationService(ICalculateIntegrationRepository context, 
            IQuotationRepository quotationContext,
            IEstimateRepository estimateContext)
        {
            this.repository = context;
            this.quotationRepository = quotationContext;
            this.estimateRepository = estimateContext;
        }

        public void Create(CalculateIntegration ci)
        {
            this.repository.Create(ci);
        }

        public void Dispose()
        {
            this.repository.Dispose();
            this.quotationRepository.Dispose();
            this.estimateRepository.Dispose();
        }

        public List<CalculateIntegration> GetAllNew()
        {
            return this.repository.GetAllNew();
        }

        public List<CalculateIntegration> GetAllReceived()
        {
            return this.repository.GetAllReceived();
        }

        public CalculateIntegration GetById(int id)
        {
            return this.repository.GetById(id);
        }

        public void Update(CalculateIntegration ci)
        {
            this.repository.Update(ci);
        }

        public void PrepareQuotationsToCalculate()
        {
            List<Quotation> quotations = this.quotationRepository.GetByStatus(QuotationStatusType.WaitCalculate);

            if (quotations.Count > 0)
            {
                foreach (Quotation quotation in quotations)
                {
                    foreach (QuotationBroker qb in quotation.QuotationBroker)
                    {
                        //TO DO -> Precisa montar o XML que será enviado ao multicálculo para inserir nesse momento
                        string xml = GetXmlFromQuotationBroker(qb);
                        CalculateIntegration ci = new CalculateIntegration(quotation, qb.BrokerInsurance.Broker, xml);
                        this.repository.Create(ci);
                    }

                    quotation.SetProcessingCalculateStatus();
                    this.quotationRepository.Update(quotation);
                }
            }
        }

        private static string GetXmlFromQuotationBroker(QuotationBroker qb)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(qb.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, qb);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }


        public void CalculateQuotations()
        {
            List<CalculateIntegration> list = this.repository.GetAllNew();

            if (list.Count > 0)
            {
                foreach (CalculateIntegration calculate in list)
                {
                    calculate.SetToSended();
                    this.repository.Update(calculate);

                    //TO DO -> Aqui vai chamar o serviço de multicálculo, passando o XML
                    string returnText = GetXmlFromCalculateIntegragion();

                    if (returnText != null)
                    {
                        calculate.SetToReceived(returnText);
                        this.repository.Update(calculate);
                    }
                }
            }
        }

        public void GenerateEstimates()
        {
            List<CalculateIntegration> list = this.repository.GetAllReceived();

            if (list.Count > 0)
            {
                foreach (CalculateIntegration calculate in list)
                {
                    calculate.SetToOnEstimate();
                    this.repository.Update(calculate);

                    try
                    {
                        //TO DO -> Aqui vai ler o XML de retorno e inserir o registro na Estimate
                        EstimateSerialization serialization = EstimateSerialization.FromXmlString(calculate.ReceiveText);

                        
                        if (serialization != null)
                        {
                            foreach (Estimate estimate in serialization.Estimates)
                            {
                                estimateRepository.Create(estimate);
                                calculate.SetToFinished();
                                this.repository.Update(calculate);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        int i = 0;
                    }
                }
            }
        }


        public static string GetXmlFromCalculateIntegragion()
        {
            return @"<EstimateSerialization>
  <Estimates>
    <Estimate price=""500.00"" status=""New"" />
    <Estimate price=""600.00"" status=""New"" />
  </Estimates>
</EstimateSerialization>";
        }
    }
}
