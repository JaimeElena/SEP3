namespace T1Driver.Models
{
    public class Order
    {
        public int id { get; set; }
        public string status { get; set; }
        public string estimatetime { get; set; }
        public string firstname { get; set; }
        public string secondname { get; set; }
        public Location driverlocation { get; set; }
        public Location customerlocation { get; set; }
        public Location destination { get; set; }
    }
}