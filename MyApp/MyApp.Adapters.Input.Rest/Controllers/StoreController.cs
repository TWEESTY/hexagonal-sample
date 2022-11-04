using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Ports.Input;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Input.Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreManagementService _storeManagementService;
        private readonly IMapper _mapper;

        public StoreController(IStoreManagementService storeManagementService, IMapper mapper)
        {
            this._storeManagementService = storeManagementService;
            this._mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StoreDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetStore(string code)
        {
            Store? storeFromApplication = this._storeManagementService.GetStoreAsync(code).GetAwaiter().GetResult();

            if (storeFromApplication == null)
            {
                return NotFound();
            }

            StoreDTO store = this._mapper.Map<StoreDTO>(storeFromApplication);

            return Ok(store);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StoreDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CompleteUpdateStore(StoreDTO updateStore)
        {
            bool result = this._storeManagementService.UpdateStoreAsync(this._mapper.Map<Store>(updateStore)).GetAwaiter().GetResult();

            // Non réaliste
            if (!result)
                return NotFound();

            return Ok(updateStore);
        }


    }
}