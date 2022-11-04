using Moq;
using MyApp.Application.Ports.Output.Repositories;
using MyApp.Domain.Models;
using MyApp.Application.Application.Services;

namespace MyApp.Application.Tests.Application.Services
{
    public class StoreManagementServiceTests
    {
        [Fact]
        public async void GetStoreAsync_ExistingStore_ShouldReturnBook()
        {
            Store returnStoreFromRepo = new Store("S01");
            returnStoreFromRepo.Name = "Store 01";

            var mockStoreRepository = new Mock<IStoreRepository>();
            mockStoreRepository.Setup(m => m.GetStoreAsync(It.IsAny<string>())).ReturnsAsync(returnStoreFromRepo);

            var storeManagementService = new StoreManagementService(mockStoreRepository.Object);

            Store? resultStore = await storeManagementService.GetStoreAsync(returnStoreFromRepo.Code);

            Assert.NotNull(resultStore);
            Assert.Equivalent(returnStoreFromRepo, resultStore);
        }

        [Fact]
        public async void GetStoreAsync_NoExistingStore_ShouldReturnNull()
        {
            Store storeToGet = new Store("S01");
            storeToGet.Name = "Store 01";

            var mockStoreRepository = new Mock<IStoreRepository>();
            mockStoreRepository.Setup(m => m.GetStoreAsync(It.IsAny<string>())).ReturnsAsync(() => null);

            var storeManagementService = new StoreManagementService(mockStoreRepository.Object);

            Store? resultStore = await storeManagementService.GetStoreAsync(storeToGet.Code);

            Assert.Null(resultStore);
        }

        [Fact]
        public async void UpdateStoreAsync_ExistingStore_ShouldReturnTrue()
        {
            Store storeToUpdate = new Store("S01");
            storeToUpdate.Name = "Store 01";

            var mockStoreRepository = new Mock<IStoreRepository>();
            mockStoreRepository.Setup(m => m.UpdateStoreAsync(It.IsAny<Store>())).ReturnsAsync(true);

            var storeManagementService = new StoreManagementService(mockStoreRepository.Object);

            bool result = await storeManagementService.UpdateStoreAsync(storeToUpdate);

            Assert.True(result);
            mockStoreRepository.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async void UpdateStoreAsync_NoExistingStore_ShouldReturnFalse()
        {
            Store storeToUpdate = new Store("S01");
            storeToUpdate.Name = "Store 01";

            var mockStoreRepository = new Mock<IStoreRepository>();
            mockStoreRepository.Setup(m => m.UpdateStoreAsync(It.IsAny<Store>())).ReturnsAsync(false);

            var storeManagementService = new StoreManagementService(mockStoreRepository.Object);

            bool result = await storeManagementService.UpdateStoreAsync(storeToUpdate);

            Assert.False(result);
            mockStoreRepository.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

    }
}
