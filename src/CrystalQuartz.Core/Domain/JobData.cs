using Quartz;
using Quartz.Util;

namespace CrystalQuartz.Core.Domain
{
    using System.Collections.Generic;

    public class JobData : ActivityNode<TriggerData>
    {
        public JobData(Key<JobKey> jobKey, IList<TriggerData> triggers): base(jobKey.Name)
        {
            Triggers = triggers;
            GroupName = jobKey.Group;
        }

        public IList<TriggerData> Triggers { get; private set; }

        public string GroupName { get; private set; }

        public string UniqueName
        {
            get
            {
                return string.Format("{0}_{1}", GroupName, Name);
            }
        }

        public bool HaveTriggers
        {
            get
            {
                return Triggers != null && Triggers.Count > 0;
            }
        }

        protected override IList<TriggerData> ChildrenActivities
        {
            get { return Triggers; }
        }
    }
}