using AuctionService.Application.Interfaces;
using AuctionService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Infrastructure.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly AppDbContext _appDBContext;
        public BidRepository(AppDbContext appDbContext)
        {
            _appDBContext = appDbContext;
        }

        public Task<Bid> Add(Bid bid)
        {
            throw new NotImplementedException();
        }

        public Task<Bid> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bid>> GetBidsForAuction(long AuctionId)
        {
            return _appDBContext.Bids.Where(b => b.AuctionId == AuctionId).ToListAsync();
        }
    }
}
