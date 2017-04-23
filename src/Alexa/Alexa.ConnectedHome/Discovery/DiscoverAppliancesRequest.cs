using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Discovery
{
    [JsonObject]
    public class DiscoverAppliancesRequest : MessagePayload
    {
        [JsonProperty("accessToken")]
        public string accessToken { get; set; }
    }
}
