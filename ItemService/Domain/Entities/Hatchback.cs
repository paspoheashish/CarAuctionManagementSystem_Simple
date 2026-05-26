namespace ItemService.Domain.Entities
{
    public class Hatchback : Vehicle
    {
        
        public long NumberOfDoors { get; set; }
        public Hatchback() { Type = "Hatchback"; }
    }
}
