namespace ItemService.Domain.Entities
{
    public class Truck : Vehicle
    {
        public int LoadCapacity { get; set; }
        public Truck() { Type = "Truck"; }
    }
}
