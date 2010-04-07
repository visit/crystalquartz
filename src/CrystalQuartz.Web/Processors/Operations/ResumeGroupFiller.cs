namespace CrystalQuartz.Web.Processors.Operations
{
    using System.Web;
    using Core;

    public class ResumeGroupFiller : OperationFiller
    {
        public ResumeGroupFiller(ISchedulerProvider schedulerProvider)
            : base(schedulerProvider)
        {
        }

        protected override void DoAction(HttpResponseBase response, HttpContextBase context)
        {
            var jobGroup = context.Request.Params["group"];
            _schedulerProvider.Scheduler.ResumeJobGroup(jobGroup);
        }
    }
}