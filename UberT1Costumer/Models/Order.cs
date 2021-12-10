namespace UberT1Costumer.Models
{
    public class Order
    {
        public int id { get; set; }
        public string status { get; set; }
        public string estimatetime { get; set; }
        public Driver driver { get; set; }
        public Costumer costumer { get; set; }
        public Location customerlocation { get; set; }
        public Location destination { get; set; }
        public double price { get; set; }
    }
}