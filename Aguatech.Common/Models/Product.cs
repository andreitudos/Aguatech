namespace Aguatech.Common.Models
{
    using Newtonsoft.Json;
    public class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("lastPurchase")]
        public object LastPurchase { get; set; }

        [JsonProperty("lastSale")]
        public object LastSale { get; set; }

        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }

        [JsonProperty("stock")]
        public long Stock { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("categoryId")]
        public long CategoryId { get; set; }

        [JsonProperty("category")]
        public object Category { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Price:C2}";
        }
    }
}
