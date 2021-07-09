using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Owin;
using Owin;
using StartDone.Analytics.Models.Filter;

[assembly: OwinStartup(typeof(StartDone.Analytics.Startup1))]

namespace StartDone.Analytics
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            

            GlobalConfiguration.Configuration.UseSqlServerStorage("StartDone_Analytics_HangFire");


            BackgroundJob.Enqueue(() => FireAndForget());

            //BackgroundJob.Schedule(() => Console.WriteLine("Analytics"), TimeSpan.FromMilliseconds(100));

            //RecurringJob.AddOrUpdate(() => test() , Cron.Minutely);

            app.UseHangfireDashboard("/backgrandjob", new DashboardOptions() { 
             Authorization = new [] {new HangfireAthorizationFilter()},
             DisplayStorageConnectionString = false,
             AppPath = "/dashboard"
             
            });
            app.UseHangfireServer();
        }

        public void FireAndForget()
        {
            Thread.Sleep(10);
            Console.WriteLine("Service Started");
        }

    }
}
