using Newtonsoft.Json;

namespace AccessControlServer.Models;

public class EventType
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; } = "";

    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; } = "";
}
