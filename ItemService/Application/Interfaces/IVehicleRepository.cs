using ItemService.Application.DTOs;
using ItemService.Domain.Entities;

namespace ItemService.Application.Interfaces
{
    public interface IVehicleRepository
    {
        Task AddVehicleAsync(Vehicle vehicle);
        Task<List<Vehicle>> SearchAsync(string? type, string? manufacturer, string? model, int? year);
        Task<Vehicle?> GetAsync(long id);
    }
}
