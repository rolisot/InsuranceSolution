using Insurance.Domain.Models;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Insurance.Domain.Serialization
{
    [XmlType("BrokerQuotation", IncludeInSchema = true)]
    public class BrokerQuotation
    {
        public BrokerQuotation()
        {
        }

        public BrokerQuotation(Quotation quotation)
        {
            this.Customer = new CustomerXml(quotation.Customer);
            this.CustomerAddress = new CustomerAddressXml(quotation.Customer.Address);
            this.quotation = quotation.QuotationId;
            this.broker = (quotation.QuotationBroker.OfType<QuotationBroker>().FirstOrDefault().BrokerInsurance).Broker.BrokerId;
            this.Quotations = new QuotationXml[quotation.QuotationBroker.Count];

            int i = 0;
            foreach (QuotationBroker qb in quotation.QuotationBroker)
            {
                this.Quotations[i] = new QuotationXml(qb.InsuranceId, qb.BrokerId);
                i++;
            }
        }

        [XmlType("Quotation", IncludeInSchema = true)]
        public sealed class QuotationXml
        {
            public QuotationXml()
            {

            }

            public QuotationXml(int insurance, decimal commission)
            {
                this.Insurance = insurance;
                this.Commission = commission;
            }

            [XmlAttribute("insurance")]
            public int Insurance { get; set; }

            [XmlAttribute("commission")]
            public decimal Commission { get; set; }
        }

        [XmlType("Customer", IncludeInSchema = true)]
        public sealed class CustomerXml
        {
            public CustomerXml()
            {

            }

            public CustomerXml(Customer customer)
            {
                this.Name = customer.Name;
                this.Cpf = customer.Cpf;
                this.Birthdate = customer.BirthDate;
            }

            [XmlAttribute("name")]
            public string Name { get; set; }

            [XmlAttribute("cpf")]
            public string Cpf { get; set; }

            [XmlAttribute("birthdate")]
            public DateTime Birthdate { get; set; }
        }

        [XmlType("CustomerAddress", IncludeInSchema = true)]
        public sealed class CustomerAddressXml
        {
            public CustomerAddressXml()
            {

            }

            public CustomerAddressXml(CustomerAddress customerAddress)
            {
                this.Address = customerAddress.Address;
                this.Cep = customerAddress.Cep;
                this.City = customerAddress.City.CityId;
                this.Neighborhood = customerAddress.Neighborhood;
            }

            [XmlAttribute("address")]
            public string Address { get; set; }

            [XmlAttribute("cep")]
            public string Cep { get; set; }

            [XmlAttribute("nb")]
            public string Neighborhood { get; set; }

            [XmlAttribute("city")]
            public int City { get; set; }
        }

        [XmlAttribute("broker")]
        public int broker { get; set; }

        [XmlAttribute("quotation")]
        public int quotation { get; set; }

        public CustomerXml Customer { get; set; }

        public CustomerAddressXml CustomerAddress { get; set; }

        [XmlArray]
        public QuotationXml[] Quotations { get; set; }


        public static BrokerQuotation FromXmlString(string xmlString)
        {
            var reader = new StringReader(xmlString);
            var serializer = new XmlSerializer(typeof(BrokerQuotation));
            var instance = (BrokerQuotation)serializer.Deserialize(reader);

            return instance;
        }

        public string GetXml()
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializerNamespaces names = new XmlSerializerNamespaces();
                names.Add("", "");

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;

                XmlWriter xmlWriter = XmlWriter.Create(sw, settings);
                XmlSerializer serializer = new XmlSerializer(this.GetType());

                tw = new XmlTextWriter(sw);
                serializer.Serialize(xmlWriter, this, names);
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
    }
}
