using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tamagochi.Api
{
    public class PokemonApiService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<PokemonResposta?> TakePokemon(string nomeOuId)
        {

            string url = $"https://pokeapi.co/api/v2/pokemon/{nomeOuId.ToLower()}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<PokemonResposta>(jsonString);
            }

            Console.WriteLine($"Erro na requisição: {response.StatusCode}");
            return null;
        }
    }
}
