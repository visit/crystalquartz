using CrystalQuartz.Core.SchedulerProviders;
using Quartz;

namespace CrystalQuartz.Web.Demo
{
    public class FakeProvider : StdSchedulerProvider
    {
        protected override System.Collections.Specialized.NameValueCollection GetSchedulerProperties()
        {
            var properties = base.GetSchedulerProperties();
            properties.Add("test1", "test1value");
            return properties;
        }

        protected override void InitScheduler(IScheduler scheduler)
        {
            
            // construct job info
            IJobDetail jobDetail = JobBuilder.Create<HelloJob>().WithIdentity("myJob").StoreDurably(true).Build();
            // fire every minute for two occurances
            ITrigger trigger =
                TriggerBuilder.Create()
                .WithSimpleSchedule(s => s.WithIntervalInMinutes(1).WithRepeatCount(2))
                .StartNow()
                .WithIdentity("myTrigger")
                .Build();
            scheduler.ScheduleJob(jobDetail, trigger);

            // construct job info
            IJobDetail jobDetail2 = JobBuilder.Create<HelloJob>().WithIdentity("myJob2").Build();

            // fire every hour
            ITrigger trigger2 =
                TriggerBuilder.Create()
                .WithIdentity("myTrigger2")
                .WithSimpleSchedule(s => s.WithIntervalInMinutes(1).WithRepeatCount(2))
                .StartNow()
                .Build();
            scheduler.ScheduleJob(jobDetail2, trigger2);

            ITrigger trigger3 = TriggerBuilder.Create()
                .WithIdentity("myTrigger3")
                .WithSimpleSchedule(s => s.WithIntervalInMinutes(5).WithRepeatCount(5))
                .ForJob("myJob2")
                .StartNow()
                .Build();
            scheduler.ScheduleJob(trigger3);

            // construct job info
            JobDataMap jobDataMap = new JobDataMap
                {
                    {"key1", "value1"},
                    {"key2", "value2"},
                    {"key3", 1l},
                    {"key4", 1d}
                };
            IJobDetail jobDetail4 = JobBuilder.Create<HelloJob>()
                .WithIdentity("myJob4", "MyOwnGroup")
                .UsingJobData(jobDataMap)
                .Build();

            // fire every hour
            ITrigger trigger4 = TriggerBuilder.Create()
                .WithIdentity("myTrigger4", jobDetail4.Key.Group)
                .WithSimpleSchedule(s => s.WithIntervalInMinutes(1).WithRepeatCount(1))
                .StartNow()
                .Build();
            scheduler.ScheduleJob(jobDetail4, trigger4);

            scheduler.PauseJob(jobDetail4.Key);
            scheduler.PauseTrigger(trigger3.Key);

            scheduler.Start();
        }
    }
}