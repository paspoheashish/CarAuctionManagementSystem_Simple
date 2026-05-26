namespace AuctionService.Domain.Entities
{
    public class Bid
    {
        public long Id { get; set; }
        public long AuctionId { get; set; }
        public decimal Amount { get; set; }
        public long Bidder { get; set; }
        public DateTime Timestamp { get; set; }

        public Auction Auction { get; set; }
    }
}
