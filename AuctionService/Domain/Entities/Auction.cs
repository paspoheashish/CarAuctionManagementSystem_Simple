namespace AuctionService.Domain.Entities
{
    public class Auction
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }
        public bool IsActive { get; set; }
        public decimal CurrentBid { get; set; }
        public long HighestBidder { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? ClosedAt { get; set; }

        public List<Bid> Bids { get; set; } = new();
    }
}
