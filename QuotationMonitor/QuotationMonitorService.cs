using Insurance.Domain.Services;
using System.Threading;
using System.Timers;
using Topshelf;
using Timer = System.Timers.Timer;

namespace QuotationMonitor
{
    public sealed class QuotationMonitorService : ServiceControl
    {
        private Timer _syncTimer;
        private static object s_lock = new object();
        private IQuotationService service;

        public QuotationMonitorService(IQuotationService context)
        {
            service = context;
        }
   

        public bool Start(HostControl hostControl)
        {
            _syncTimer = new Timer();
            _syncTimer.Interval = 5000;
            _syncTimer.Enabled = true;
            _syncTimer.Elapsed += RunJob;
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _syncTimer.Enabled = false;
            return true;
        }

        // Job runner event, with lock if the job still running
        private void RunJob(object state, ElapsedEventArgs elapsedEventArgs)
        {
            // Prevents the job firing until it finishes its job 
            if (Monitor.TryEnter(s_lock))
            {
                try
                {
                    service.AddQuotationBrokers();
                }
                finally
                {
                    // unlock the job 
                    Monitor.Exit(s_lock);
                }
            }
        }
    }
}
