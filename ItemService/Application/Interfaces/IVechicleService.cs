using ItemService.Application.DTOs;
using ItemService.Domain.Entities;

namespace ItemService.Application.Interfaces
{
    public interface IVechicleService
    {
        Task<Vehicle> AddVehicleAsync(AddVehicleDto dto);
        Task<IEnumerable<Vehicle>> SearchAsync(string? type, string? manufacturer, string? model, int? year);
        Task<Vehicle?> GetAsync(long id);
    }
}
