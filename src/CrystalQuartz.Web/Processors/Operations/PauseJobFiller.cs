namespace CrystalQuartz.Web.Processors.Operations
{
    using System.Web;
    using Core;

    public class PauseJobFiller : OperationFiller
    {
        public PauseJobFiller(ISchedulerProvider schedulerProvider) : base(schedulerProvider)
        {
        }

        protected override void DoAction(HttpResponseBase response, HttpContextBase context)
        {
            var jobName = context.Request.Params["job"];
            var jobGroup = context.Request.Params["group"];
            _schedulerProvider.Scheduler.PauseJob(jobName, jobGroup);
        }
    }
}