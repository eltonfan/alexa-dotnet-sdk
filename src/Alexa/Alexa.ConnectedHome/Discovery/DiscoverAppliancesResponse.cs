using Newtonsoft.Json;
using System.Collections.Generic;

namespace Alexa.ConnectedHome.Discovery
{
    [JsonObject]
    public class DiscoverAppliancesResponse : MessagePayload
    {
        [JsonProperty("discoveredAppliances")]
        public ApplianceDetails[] DiscoveredAppliances { get; set; }
    }
}
