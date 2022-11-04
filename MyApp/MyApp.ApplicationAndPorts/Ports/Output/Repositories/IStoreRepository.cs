using MyApp.Domain.Models;

namespace MyApp.Application.Ports.Output.Repositories
{
    public interface IStoreRepository : IRepository
    {
        public Task<Store?> GetStoreAsync(string id);
        public Task<bool> UpdateStoreAsync(Store book);
    }
}