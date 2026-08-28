using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tamagochi.Api
{
    public class PokemonResposta
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Nome { get; set; } = "";

        [JsonPropertyName("height")]
        public int Altura { get; set; }

        [JsonPropertyName("weight")]
        public int Peso { get; set; }

        [JsonPropertyName("types")]
        public List<TipoSlot> Tipos { get; set; } = new();
    }

    public class TipoSlot
    {
        [JsonPropertyName("type")]
        public NomeSimples Type { get; set; } = new();
    }

    public class NomeSimples
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
    }
}
