using ItemService.Application.DTOs;

namespace ApiGateway.Application.Interfaces
{
    public interface IItemClient
    {
        Task<HttpResponseMessage> Search(string? type, string? manufacturer, string? model, int? year);
        Task<HttpResponseMessage> Get(long id);
        Task<HttpResponseMessage> Add(AddVehicleDto dto);
    }
}
