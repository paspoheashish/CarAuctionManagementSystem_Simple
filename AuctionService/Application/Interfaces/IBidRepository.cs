using AuctionService.Domain.Entities;

namespace AuctionService.Application.Interfaces
{
    public interface IBidRepository
    {
        Task<Bid> Get(long id);
        Task<Bid> Add(Bid bid);
        Task<List<Bid>> GetBidsForAuction(long AuctionId);
    }
}
