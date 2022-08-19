using JCEvents.Dashboard.DataAccess.Enums;

namespace JCEvents.Dashboard.DataAccess.Domain
{
    public class Stock
    {
        public string Id { get; set; }
        public string ItemName { get; set; }
        public string ShortDescription { get; set; }
        public int Quantity { get; set; }
        public Status StatusId { get; set; }
        public DateTime ServiceDate { get; set; }
        public Group GroupId { get; set; }
        public int Weight { get; set; }
        public bool IsAssigned { get; set; }
    }
}
