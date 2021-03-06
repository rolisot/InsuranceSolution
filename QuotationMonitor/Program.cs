﻿using Topshelf;
using Topshelf.Ninject;

namespace QuotationMonitor
{
    public class Program
    {

        public static void Main(string[] args)
        {
            HostFactory.Run(x => {
                x.UseNinject(new QuotationModule());
                x.Service<QuotationMonitorService>(s =>
                {
                    s.ConstructUsingNinject();
                    s.WhenStarted((service, hostControl) => service.Start(hostControl));
                    s.WhenStopped((service, hostControl) => service.Stop(hostControl));
                });

                x.RunAsLocalSystem();
                x.SetDescription("Monitor for icoming quotations");
                x.SetDisplayName("Quotation Monitor");
                x.SetServiceName("QuotationMonitorService");
            });
        }
    }
}
