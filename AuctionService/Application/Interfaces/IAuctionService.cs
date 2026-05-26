using AuctionService.Domain.Entities;

namespace AuctionService.Application.Interfaces
{
    public interface IAuctionService
    {
        Task<Auction> StartAuctionAsync(long vehicleId);
        Task<Auction> CloseAuctionAsync(long auctionId);
        Task<Auction?> PlaceBidAsync(long auctionId, decimal amount, long bidder);
        Task<Auction?> GetAuctionAsync(long id);
    }
}
