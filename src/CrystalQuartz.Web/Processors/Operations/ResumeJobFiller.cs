using System.Web;
using CrystalQuartz.Core.SchedulerProviders;
using Quartz;

namespace CrystalQuartz.Web.Processors.Operations
{
    public class ResumeJobFiller : OperationFiller
    {
        public ResumeJobFiller(ISchedulerProvider schedulerProvider)
            : base(schedulerProvider)
        {
        }

        protected override void DoAction(HttpResponseBase response, HttpContextBase context)
        {
            var jobName = context.Request.Params["job"];
            var jobGroup = context.Request.Params["group"];
            _schedulerProvider.Scheduler.ResumeJob(new JobKey(jobName, jobGroup));
        }
    }
}