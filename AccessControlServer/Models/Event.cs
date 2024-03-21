using Newtonsoft.Json;

namespace AccessControlServer.Models;

public class Event
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; } 

    [JsonProperty(PropertyName = "severity")]
    public string Severity { get; set; } = "";

    [JsonProperty(PropertyName = "severityId")]
    public int SeverityId { get; set; }

    [JsonProperty(PropertyName = "message")]
    public string Message { get; set; } = "";

    [JsonProperty(PropertyName = "details")]
    public string Details { get; set; } = "";

    [JsonProperty(PropertyName = "arrivalTime")]
    public DateTime? ArrivalTime { get; set; }

}
public class EventModel
{
    [JsonProperty(PropertyName = "severityId")]
    public int SeverityId { get; set; }

    [JsonProperty(PropertyName = "message")]
    public string Message { get; set; } = "";

    [JsonProperty(PropertyName = "details")]
    public string Details { get; set; } = "";

}

