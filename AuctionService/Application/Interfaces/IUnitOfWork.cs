namespace AuctionService.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}
