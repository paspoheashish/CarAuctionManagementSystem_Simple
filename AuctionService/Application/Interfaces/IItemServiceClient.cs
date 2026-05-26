namespace AuctionService.Application.Interfaces
{
    public interface IItemServiceClient
    {
        Task<bool> VehicleExists(long vehicleId);
    }
}
