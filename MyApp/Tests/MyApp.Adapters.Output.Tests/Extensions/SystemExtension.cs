using System.Text.Json;

namespace MyApp.Adapters.Output.Tests.Extensions
{
    public static class SystemExtension
    {
        public static T? Clone<T>(this T source)
        {
            var serialized = JsonSerializer.Serialize(source);
            return JsonSerializer.Deserialize<T>(serialized);
        }
    }
}
