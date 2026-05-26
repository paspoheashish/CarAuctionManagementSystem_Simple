using AuctionService.Domain.Entities;

namespace AuctionService.Application.Interfaces
{
    public interface IAuctionRepository
    {
        Task<Auction?> Get(long id);
        Task<Auction?> GetAuctionWithBids(long id);
        Task<Auction?> GetActive(long vehicleId, bool isActive);
        Task Add(Auction auction);
    }
}
