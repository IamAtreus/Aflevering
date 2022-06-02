using Vicevært.Contract;
using Vicevært.Contract.Dtos;

namespace Vicevært.Web.Infrastructure
{
    public class LejerServiceProxy : ILejerService
    {
        private readonly HttpClient _client;


        public LejerServiceProxy(HttpClient client)
        {
            _client = client;
        }



        async Task<LejerDto?> ILejerService.GetAsync(int id)
        {
            return await _client.GetFromJsonAsync<LejerDto?>($"api/Lejer/{id}");
        }

        async Task<IEnumerable<LejerDto>> ILejerService.GetAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<LejerDto>>($"https://localhost:5001/api/Lejer");
        }
    }
}
