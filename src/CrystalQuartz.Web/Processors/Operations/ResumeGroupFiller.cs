using System.Web;
using CrystalQuartz.Core.SchedulerProviders;
using Quartz;
using Quartz.Impl.Matchers;

namespace CrystalQuartz.Web.Processors.Operations
{

    public class ResumeGroupFiller : OperationFiller
    {
        public ResumeGroupFiller(ISchedulerProvider schedulerProvider)
            : base(schedulerProvider)
        {
        }

        protected override void DoAction(HttpResponseBase response, HttpContextBase context)
        {
            var jobGroup = context.Request.Params["group"];
            _schedulerProvider.Scheduler.ResumeJobs(GroupMatcher<JobKey>.GroupEquals(jobGroup));
        }
    }
}