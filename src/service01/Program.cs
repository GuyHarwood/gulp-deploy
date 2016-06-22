using System;
using System.Timers;
using Topshelf;

namespace service01
{
    public class HappySpeakingClock
    {
        private readonly Timer _timer;
        public HappySpeakingClock()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("The time is {0} and all is well", DateTime.Now);
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }

    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<HappySpeakingClock>(s =>
                {
                    s.ConstructUsing(name => new HappySpeakingClock());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Sample Windows Service Description");
                x.SetDisplayName("Sample Windows Service");
                x.SetServiceName("HappySpeakingClock");
            });
        }
    }
}