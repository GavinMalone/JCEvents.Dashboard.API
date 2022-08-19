using JCEvents.Dashboard.DataAccess.Enums;

namespace JCEvents.Dashboard.DataAccess.Domain
{
    public class Job
    {
        public string Quotation { get; set; }
        public string Title { get; set; }
        public string ContactInformation { get; set; }
        public string Venue { get; set; }
        public DateTime EventDate { get; set; }
        public JobType JobType { get; set; }
        public bool IsActive { get; set; }
    }
}
