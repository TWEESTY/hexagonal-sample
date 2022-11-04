using AutoMapper;
using MyApp.Adapters.Input.Rest.Controllers;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Input.Rest.AutoMapper
{
    internal class StoreProfile : Profile
    {
        public StoreProfile()
        {

            this.CreateMap<Store, StoreDTO>();
            this.CreateMap<StoreDTO, Store>()
                .ConstructUsing((StoreDTO storeDTO) => StoreFactory.Instance.CreateStore(storeDTO));
        }
    }
}
