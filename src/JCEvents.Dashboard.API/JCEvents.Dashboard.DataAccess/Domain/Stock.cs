using JCEvents.Dashboard.DataAccess.Enums;

namespace JCEvents.Dashboard.DataAccess.Domain
{
    public class Stock
    {
        public string Id { get; set; }
        public string ItemName { get; set; }
        public string ShortDescription { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }
        public DateTime ServiceDate { get; set; }
        public Group Group { get; set; }
        public int Weight { get; set; }
    }
}
