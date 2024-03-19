using Newtonsoft.Json;

namespace AccessControlServer.Models
{
    public class EventsPerYear
    {
        [JsonProperty(PropertyName = "year")]
        public string Year { get; set; } = "";

        [JsonProperty(PropertyName = "month")]
        public string Month { get; set; } = "3";

        [JsonProperty(PropertyName = "eventType")]
        public string EventType { get; set; } = "";

        [JsonProperty(PropertyName = "total")]
        public string Total { get; set; } = "";

    }
}
