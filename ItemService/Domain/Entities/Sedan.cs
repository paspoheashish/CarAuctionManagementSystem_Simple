namespace ItemService.Domain.Entities
{
    public class Sedan : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public Sedan() { Type = "Sedan"; }
    }
}
