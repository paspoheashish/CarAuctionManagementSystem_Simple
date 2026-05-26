
using AuctionService.Application.DTOs;

namespace AuctionService.Infrastructure.Clients
{
    public class NotificationClient
    {
        private readonly HttpClient _http;

        public NotificationClient(HttpClient http)
        {
            _http = http;
        }
    }
}
