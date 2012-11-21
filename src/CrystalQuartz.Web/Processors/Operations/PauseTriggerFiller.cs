using System.Web;
using CrystalQuartz.Core.SchedulerProviders;
using Quartz;

namespace CrystalQuartz.Web.Processors.Operations
{
    public class PauseTriggerFiller : OperationFiller
    {
        public PauseTriggerFiller(ISchedulerProvider schedulerProvider)
            : base(schedulerProvider)
        {
        }

        protected override void DoAction(HttpResponseBase response, HttpContextBase context)
        {
            var triggerName = context.Request.Params["trigger"];
            var jobGroup = context.Request.Params["group"];
            _schedulerProvider.Scheduler.PauseTrigger(new TriggerKey(triggerName, jobGroup));
        }
    }
}