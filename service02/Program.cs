using System;
using System.Timers;
using Topshelf;

namespace service01
{
    public class GrumpySpeakingClock
    {
        private readonly Timer _timer;
        public GrumpySpeakingClock()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("The time is {0} and all is not well", DateTime.Now);
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
                x.Service<GrumpySpeakingClock>(s =>
                {
                    s.ConstructUsing(name => new GrumpySpeakingClock());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Sample Windows Service Description");
                x.SetDisplayName("Sample Windows Service");
                x.SetServiceName("GrumpySpeakingClock");
            });
        }
    }
}