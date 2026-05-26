namespace ItemService.Domain.Entities
{
    public class SUV : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public SUV() { Type = "SUV"; }
    }
}
