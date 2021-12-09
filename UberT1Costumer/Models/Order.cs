namespace UberT1Costumer.Models
{
    public class Order
    {
        public int id { get; set; }
        public string status { get; set; }
        public string estimatetime { get; set; }
        public string firstname { get; set; }
        public string secondname { get; set; }
        public Location location { get; set; }
        public Location direction { get; set; }
        public double price { get; set; }
    }
}