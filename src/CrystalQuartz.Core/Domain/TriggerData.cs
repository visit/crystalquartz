namespace CrystalQuartz.Core.Domain
{
    using System;

    public class TriggerData : Activity
    {
        public TriggerData(string name, ActivityStatus status) : base(name, status)
        {
        }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? NextFireDate { get; set; }

        public DateTimeOffset? PreviousFireDate { get; set; }
    }
}