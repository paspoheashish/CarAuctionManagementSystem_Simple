using AuctionService.Application.Interfaces;
using AuctionService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Infrastructure.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AppDbContext _appDBContext;
        public AuctionRepository(AppDbContext appDbContext) 
        {
            _appDBContext = appDbContext; 
        }
        public Task Add(Auction auction)
        {
            _appDBContext.Add(auction);
            return Task.CompletedTask;
        }

        public Task<Auction?> Get(long id)
        {
            return _appDBContext.Auctions.FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task<Auction?> GetActive(long vehicleId, bool isActive)
        {
            return _appDBContext.Auctions.FirstOrDefaultAsync(a => a.VehicleId == vehicleId && a.IsActive == isActive);
        }

        public Task<Auction?> GetAuctionWithBids(long id)
        {
            var auction = _appDBContext.Auctions
                      .Where(a => a.Id == id)
                      .Select(a => new Auction
                      {
                          Id = a.Id,
                          VehicleId = a.VehicleId,
                          IsActive = a.IsActive,
                          CurrentBid = a.CurrentBid,
                          HighestBidder = a.HighestBidder,
                          StartedAt = a.StartedAt,
                          ClosedAt = a.ClosedAt,
                          Bids = a.Bids.Select(b => new Bid
                          {
                              Id = b.Id,
                              Amount = b.Amount,
                              Bidder = b.Bidder,
                              Timestamp = DateTime.UtcNow
                          }).ToList()
                      }).FirstOrDefaultAsync();

            return auction;
        }
    }
}
