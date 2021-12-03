namespace Uber2.Models
{
    public class Order
    {
        public int order_id { get; set; }
        public long from { get; set; }
        public long to { get; set; }
        public string orderdate { get; set; }
    }
}