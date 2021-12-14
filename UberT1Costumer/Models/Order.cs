namespace UberT1Costumer.Models
{
    public class Order
    {
        public int id { get; set; }
        public string status { get; set; }
        public string estimatedTime { get; set; }
        public Driver driver { get; set; }
        public Costumer customer { get; set; }
        public Location customerLocation { get; set; }
        public string destinationStreetName { get; set; }
        public string distance { get; set; }
        public string price { get; set; }
    }
}