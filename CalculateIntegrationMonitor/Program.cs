using Topshelf;
using Topshelf.Ninject;

namespace CalculateIntegrationMonitor
{
    public class Program
    {

        public static void Main(string[] args)
        {
            HostFactory.Run(x => {
                x.UseNinject(new CalculateIntegrationModule());
                x.Service<CalculateIntegrationMonitorService>(s =>
                {
                    s.ConstructUsingNinject();
                    s.WhenStarted((service, hostControl) => service.Start(hostControl));
                    s.WhenStopped((service, hostControl) => service.Stop(hostControl));
                });

                x.RunAsLocalSystem();
                x.SetDescription("Monitor for calculate integration");
                x.SetDisplayName("Calculate Integration Monitor");
                x.SetServiceName("CalculateIntegrationMonitorService");
            });
        }
    }
}
