using MockQueryable.Moq;
using Moq;
using MyApp.Adapters.Output.Context;
using MyApp.Adapters.Output.Entities;
using MyApp.Adapters.Output.Repositories;
using MyApp.Adapters.Output.Tests.Extensions;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Output.Tests.Repositories
{
    public class StoreRepositoryTests
    {
        [Fact]
        public async void GetStoreAsync_ExistingStore_ShouldReturnStore()
        {
            var codeStoreToGet = "S02";
            var storesInRepository = new List<StoreEntity>
            {
                new StoreEntity() { Code = "S01", Name = "Store 01" },
                new StoreEntity() { Code = "S02", Name = "Store 02" },
            };

            var StoresSet = storesInRepository.AsQueryable().BuildMockDbSet();

            var context = new Mock<InMemoryContext>();
            context.Setup(c => c.Stores).Returns(StoresSet.Object);

            var repository = new StoreRepository(context.Object, initDatabase: false);

            var returnStore = await repository.GetStoreAsync(codeStoreToGet);

            Assert.NotNull(returnStore);
            Assert.Equivalent(storesInRepository.Single(b => b.Code == codeStoreToGet), returnStore);
        }

        [Fact]
        public async void GetStoreAsync_NoExistingStore_ShouldReturnNull()
        {
            var codeStoreToGet = "S03";
            var storesInRepository = new List<StoreEntity>
            {
                new StoreEntity() { Code = "S01", Name = "Store 01" },
                new StoreEntity() { Code = "S02", Name = "Store 02" },
            };

            var StoresSet = storesInRepository.AsQueryable().BuildMockDbSet();

            var context = new Mock<InMemoryContext>();
            context.Setup(c => c.Stores).Returns(StoresSet.Object);

            var repository = new StoreRepository(context.Object, initDatabase: false);

            var returnStore = await repository.GetStoreAsync(codeStoreToGet);

            Assert.Null(returnStore);
        }

        [Fact]
        public async void UpdateStoreAsync_ExistingStore_ShouldReturnTrue()
        {
            var codeStoreToUpdate = "S02";
            var storesInRepository = new List<StoreEntity>
            {
                new StoreEntity() { Code = "S01", Name = "Store 01" },
                new StoreEntity() { Code = "S02", Name = "Store 02" },
            };

            var initialStoresInRepository = storesInRepository.Clone();

            Store storeToUpdate = new Store(codeStoreToUpdate);
            storeToUpdate.Name = "New store 02";

            var storesSet = storesInRepository.AsQueryable().BuildMockDbSet();

            var context = new Mock<InMemoryContext>();
            context.Setup(c => c.Stores).Returns(storesSet.Object);

            var repository = new StoreRepository(context.Object, initDatabase: false);

            var result = await repository.UpdateStoreAsync(storeToUpdate);

            Assert.True(result);
            Assert.Equal(storeToUpdate.Name, storesInRepository.Single(x => x.Code == codeStoreToUpdate).Name);
            storesInRepository
                .Where(b => b.Code != codeStoreToUpdate).ToList()
                .ForEach(b => Assert.Equivalent(b, initialStoresInRepository.Single(x => x.Code == b.Code)));
        }

        [Fact]
        public async void UpdateStoreAsync_NoExistingStore_ShouldReturnFalse()
        {
            var codeStoreToUpdate = "S04";
            var storesInRepository = new List<StoreEntity>
            {
                new StoreEntity() { Code = "S01", Name = "Store 01" },
                new StoreEntity() { Code = "S02", Name = "Store 02" },
            };

            var initialStoresInRepository = storesInRepository.Clone();

            Store storeToUpdate = new Store(codeStoreToUpdate);
            storeToUpdate.Name = "New store 02";

            var storesSet = storesInRepository.AsQueryable().BuildMockDbSet();

            var context = new Mock<InMemoryContext>();
            context.Setup(c => c.Stores).Returns(storesSet.Object);

            var repository = new StoreRepository(context.Object, initDatabase: false);

            var result = await repository.UpdateStoreAsync(storeToUpdate);

            Assert.False(result);
            Assert.Equivalent(initialStoresInRepository, storesInRepository);
        }
    }
}