using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Output.Entities
{
    public class StoreEntity : IStoreIDO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}
