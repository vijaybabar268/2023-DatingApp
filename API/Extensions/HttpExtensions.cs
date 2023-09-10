using API.Helpers;
using System.Text.Json;

namespace API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse reponse, PaginationHeader header)
        {
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            reponse.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptions));
            reponse.Headers.Add("Access-Control-Expose-Headers", "Pagination");

        }
    }
}
