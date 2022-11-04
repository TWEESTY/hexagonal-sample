using Microsoft.EntityFrameworkCore;
using MyApp.Adapters.Output.Context;
using MyApp.Adapters.Output.Entities;
using MyApp.Application.Ports.Output.Repositories;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Output.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly InMemoryContext _context;

        public StoreRepository(InMemoryContext context, bool initDatabase = true)
        {
            this._context = context;

            // Trick to force the OnModelCreating (i.e. https://github.com/dotnet/efcore/issues/11666)
            if (initDatabase)
                this._context.Database.EnsureCreated();
        }

        public async Task<Store?> GetStoreAsync(string code)
        {
            StoreEntity? storeEntity = await this._context.Stores.FirstOrDefaultAsync(x => x.Code == code);
            if (storeEntity == null)
            {
                return null;
            }
            
            return StoreFactory.Instance.CreateStore(storeEntity);
        }

        public async Task<bool> UpdateStoreAsync(Store store)
        {
            StoreEntity? storeEntity = await this._context.Stores.FirstOrDefaultAsync(x => x.Code == store.Code);
            if (storeEntity == null)
            {
                return false;
            }

            storeEntity.Name = store.Name;

            return true;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return this._context.SaveChangesAsync(cancellationToken);
        }
    }
}