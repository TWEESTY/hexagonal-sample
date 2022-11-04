using MyApp.Application.Ports.Input;
using MyApp.Application.Ports.Output.Repositories;
using MyApp.Domain.Models;

namespace MyApp.Application.Application.Services
{
    public class StoreManagementService : IStoreManagementService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreManagementService(IStoreRepository storeRepository)
        {
            this._storeRepository = storeRepository;
        }

        public Task<Store?> GetStoreAsync(string code)
        {
            return this._storeRepository.GetStoreAsync(code);
        }

        public async Task<bool> UpdateStoreAsync(Store store)
        {
            bool updated = await this._storeRepository.UpdateStoreAsync(store);
            if (!updated)
            {
                return false;
            }

            await this._storeRepository.SaveChangesAsync();
            return true;
        }
    }
}
