namespace UberT1Costumer.Models
{
    public class Location
    {
        public int id { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        
        public string streetname { get; set; }

        public Location(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }

        public double GetLat()
        {
            return lat;
        }

        public double GetLng()
        {
            return lng;
        }
    }
}