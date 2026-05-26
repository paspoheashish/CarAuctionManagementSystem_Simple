using AuctionService.Application.DTOs;

namespace ApiGateway.Application.Interfaces
{
    public interface IAuctionClient
    {
        Task<HttpResponseMessage> Get(long vehicleId);
        Task<HttpResponseMessage> Bid(long auctionId, PlaceBidDto dto);
        Task<HttpResponseMessage> Close(long id);
        Task<HttpResponseMessage> Start(StartAuctionDto dto);
    }
}
