using Newtonsoft.Json;

namespace AccessControlServer.Models;

public class Events
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; } = "";

    [JsonProperty(PropertyName = "eventtype")]
    public string EventType { get; set; } = "";

    [JsonProperty(PropertyName = "message")]
    public string Message { get; set; } = "";

    [JsonProperty(PropertyName = "details")]
    public string Details { get; set; } = "";

    [JsonProperty(PropertyName = "arrivalTime")]
    public DateTime? ArrivalTime { get; set; }

}
