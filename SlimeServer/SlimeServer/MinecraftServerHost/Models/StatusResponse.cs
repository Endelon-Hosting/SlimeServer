namespace SlimeServer.MinecraftServerHost.Models
{
    using Newtonsoft.Json;
    using System;

    public partial class StatusResponse
    {
        [JsonProperty("version")]
        public Version Version { get; set; }

        [JsonProperty("players")]
        public Players Players { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("favicon")]
        public string Favicon { get; set; }
    }

    public partial class Description
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class Players
    {
        [JsonProperty("max")]
        public long Max { get; set; }

        [JsonProperty("online")]
        public long Online { get; set; }

        [JsonProperty("sample")]
        public Sample[] Sample { get; set; }
    }

    public partial class Sample
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }
    }

    public partial class Version
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("protocol")]
        public long Protocol { get; set; }
    }
}
