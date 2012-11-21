using CrystalQuartz.Core;
using CrystalQuartz.Web.FrontController;
using CrystalQuartz.Web.FrontController.ViewRendering;
using Quartz;

namespace CrystalQuartz.Web.Processors
{
    public class JobFiller : MasterFiller
    {
        public JobFiller(IViewEngine viewEngine, ISchedulerDataProvider schedulerDataProvider)
            : base(viewEngine, schedulerDataProvider)
        {
        }

        protected override void FillViewData(ViewData viewData)
        {
            var jobName = Request.Params["job"];
            var jobGroup = Request.Params["group"];
            viewData.Data["mainContent"] = "job";
            viewData.Data["jobDetails"] = SchedulerDataProvider.GetJobDetailsData(new JobKey(jobName, jobGroup));
        }
    }
}