using Moq;
using MyApp.Domain.Models;
using MyApp.Adapters.Input.Rest.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApp.Adapters.Input.Rest.AutoMapper;
using MyApp.Application.Ports.Input;

namespace MyApp.Adapters.Input.Rest.Tests.Controllers
{
    public class StoreControllerTests
    {
        private IMapper _mapper;

        public StoreControllerTests()
        {

            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<StoreProfile>()));
        }

        [Fact]
        public void GetStore_ExistingStore_ShouldReturnOk()
        {
            Store returnStoreByService = new Store("S01");
            returnStoreByService.Name = "Store 01";

            var mockStoreManagementService = new Mock<IStoreManagementService>();
            mockStoreManagementService.Setup(m => m.GetStoreAsync(It.IsAny<string>())).ReturnsAsync(returnStoreByService);

            var StoreController =
                new StoreController(mockStoreManagementService.Object, this._mapper);

            IActionResult result = StoreController.GetStore(returnStoreByService.Code);

            Assert.IsType<OkObjectResult>(result);

            var resultStore = ((StoreDTO)((OkObjectResult)result).Value);
            Assert.Equivalent(returnStoreByService, resultStore);
        }

        [Fact]
        public void GetStore_NoExistingStore_ShouldReturnNotFound()
        {
            var mockStoreManagementService = new Mock<IStoreManagementService>();
            mockStoreManagementService.Setup(m => m.GetStoreAsync(It.IsAny<string>())).ReturnsAsync(() => null);

            var StoreController =
                new StoreController(mockStoreManagementService.Object, this._mapper);

            IActionResult result = StoreController.GetStore("S01");

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CompleteUpdateStore_ExistingStore_ShouldReturnOk()
        {
            var storeToUpdate = new StoreDTO()
            {
                Code = "S01",
                Name = "Store 01"
            };

            var mockStoreManagementService = new Mock<IStoreManagementService>();
            mockStoreManagementService.Setup(m => m.UpdateStoreAsync(It.IsAny<Store>())).ReturnsAsync(true);

            var StoreController =
                new StoreController(mockStoreManagementService.Object, this._mapper);

            IActionResult result = StoreController.CompleteUpdateStore(storeToUpdate);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CompleteUpdateStore_NonExistingStore_ShouldReturnNotFound()
        {
            var storeToUpdate = new StoreDTO()
            {
                Code = "S01",
                Name = "Store 01"
            };

            var mockStoreManagementService = new Mock<IStoreManagementService>();
            mockStoreManagementService.Setup(m => m.UpdateStoreAsync(It.IsAny<Store>())).ReturnsAsync(false);

            StoreController StoreController =
                new StoreController(mockStoreManagementService.Object, this._mapper);

            IActionResult result = StoreController.CompleteUpdateStore(storeToUpdate);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
