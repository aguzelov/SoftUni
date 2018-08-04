using Newtonsoft.Json;

namespace Instagraph.DataProcessor.Models.Export
{
    public class PopularUserExportDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Followers")]
        public int Followers { get; set; }
    }
}