namespace ItemService.Domain.Entities
{
    public abstract class Vehicle
    {
        public long Id { get; set; } 
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal StartingBid { get; set; }

        public Vehicle() { }

        public Vehicle(string type, string manufacturer, string model, int year, decimal startingBid)
        {
            Type   = type;
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            StartingBid = startingBid;
        }
    }
}
