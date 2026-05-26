
using ApiGateway.Application.Interfaces;
using AuctionService.Application.DTOs;

namespace AuctionService.Infrastructure.Clients
{
    public class NotificationClient : INotificationClient
    {
        private readonly HttpClient _http;

        public NotificationClient(HttpClient http)
        {
            _http = http;
        }
    }
}
