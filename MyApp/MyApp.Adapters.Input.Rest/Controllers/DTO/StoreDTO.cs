using MyApp.Domain.Models;

namespace MyApp.Adapters.Input.Rest.Controllers
{
    public class StoreDTO : IStoreIDO
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}
