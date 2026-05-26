using ItemService.Application.DTOs;
using ItemService.Application.Interfaces;
using ItemService.Domain.Entities;
using ItemService.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ItemService.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDBContext _appDBContext;
        public VehicleRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public Task AddVehicleAsync(Vehicle vehicle)
        {
            _appDBContext.Vehicles.AddAsync(vehicle);
            return Task.CompletedTask;
        }

        public Task<Vehicle?> GetAsync(long id)
        {
            var vehicle = _appDBContext.Vehicles.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(vehicle);
        }

        public Task<List<Vehicle>> SearchAsync(string? type, string? manufacturer, string? model, int? year)
        {
            var query = _appDBContext.Vehicles.AsQueryable();

            if (!string.IsNullOrEmpty(type))
                query = query.Where(v => v.Type == type);

            if (!string.IsNullOrEmpty(manufacturer))
                query = query.Where(v => v.Manufacturer == manufacturer);

            if (!string.IsNullOrEmpty(model))
                query = query.Where(v => v.Model == model);

            if (year.HasValue)
                query = query.Where(v => v.Year == year);

            return Task.FromResult(query.ToList());
        }
    }
}
