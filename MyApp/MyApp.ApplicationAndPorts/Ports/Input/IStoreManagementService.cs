using MyApp.Domain.Models;

namespace MyApp.Application.Ports.Input
{
    public interface IStoreManagementService
    {
        public Task<Store?> GetStoreAsync(string code);
        public Task<bool> UpdateStoreAsync(Store store);
    }
}
