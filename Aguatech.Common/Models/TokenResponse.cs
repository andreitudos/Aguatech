namespace Aguatech.Common.Models
{
    using Newtonsoft.Json;

    public class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }


        [JsonProperty("expiration")]
        public string Expiration { get; set; }
    }
}
