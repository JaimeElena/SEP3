namespace UberT1Costumer.Models
{
    public class Order
    {
        public int id { get; set; }
        public string status { get; set; }
        public string estimateTime { get; set; }
        public Driver driver { get; set; }
        public Costumer costumer { get; set; }
        public Location customerLocation { get; set; }
        public string destinationName { get; set; }
        public double price { get; set; }
    }
}