namespace T1Driver.Models
{
    public class Order
    {
        public int id { get; set; }
        public string status { get; set; }
        public string customer { get; set; }
        public string driver { get; set; }
        public string customerStreetName { get; set; }
        public string destinationStreetName { get; set; }
    }
}