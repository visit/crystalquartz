namespace CrystalQuartz.Web.Processors.Operations
{
    using System.Web;
    using Core;

    public class StartSchedulerFiller : OperationFiller
    {
        public StartSchedulerFiller(ISchedulerProvider schedulerProvider)
            : base(schedulerProvider)
        {
        }

        protected override void DoAction(HttpResponseBase response, HttpContextBase context)
        {
            _schedulerProvider.Scheduler.Start();
        }
    }
}