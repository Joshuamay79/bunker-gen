using System.Text.Json;

namespace BunkerGen.Services
{
    public static class JsonLoaderService
    {
        public static async Task<T> Load<T>(string fileName)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            using FileStream openStream = File.OpenRead(fileName);
            var jsonData =
                await JsonSerializer.DeserializeAsync<T>(openStream, options);

            return jsonData;
        }
    }
}