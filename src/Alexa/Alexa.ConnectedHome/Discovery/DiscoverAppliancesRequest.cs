using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Discovery
{
    [JsonObject]
    public class DiscoverAppliancesRequest : Elton.ConnectedHome.MessagePayload
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}
