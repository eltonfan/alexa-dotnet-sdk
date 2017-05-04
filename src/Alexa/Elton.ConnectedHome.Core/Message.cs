using Newtonsoft.Json;

namespace Elton.ConnectedHome
{
    /// <summary>
    /// The skill adapter directive.
    /// </summary>
    [JsonObject]
    public class Message
    {
        [JsonProperty("header")]
        public MessageHeader Header { get; set; }
        [JsonProperty("payload")]
        public MessagePayload Payload { get; set; }
    }
}
