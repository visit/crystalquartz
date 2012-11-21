using Quartz;

namespace CrystalQuartz.Web.Processors.Operations
{
    using System.Web;
    using Core;
    using Core.SchedulerProviders;

    public class ResumeTriggerFiller : OperationFiller
    {
        public ResumeTriggerFiller(ISchedulerProvider schedulerProvider)
            : base(schedulerProvider)
        {
        }

        protected override void DoAction(HttpResponseBase response, HttpContextBase context)
        {
            var triggerName = context.Request.Params["trigger"];
            var jobGroup = context.Request.Params["group"];
            _schedulerProvider.Scheduler.ResumeTrigger(new TriggerKey(triggerName, jobGroup));
        }
    }
}