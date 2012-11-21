using Quartz;
using Quartz.Impl.Matchers;

namespace CrystalQuartz.Web.Processors.Operations
{
    using System.Web;
    using Core.SchedulerProviders;

    public class PauseGroupFiller : OperationFiller
    {
        public PauseGroupFiller(ISchedulerProvider schedulerProvider)
            : base(schedulerProvider)
        {
        }

        protected override void DoAction(HttpResponseBase response, HttpContextBase context)
        {
            var jobGroup = context.Request.Params["group"];
            _schedulerProvider.Scheduler.PauseJobs(GroupMatcher<JobKey>.GroupEquals(jobGroup) );
        }
    }
}