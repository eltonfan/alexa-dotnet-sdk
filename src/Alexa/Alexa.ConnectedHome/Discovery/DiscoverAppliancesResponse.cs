using Newtonsoft.Json;
using System.Collections.Generic;

namespace Alexa.ConnectedHome.Discovery
{
    [JsonObject]
    public class DiscoverAppliancesResponse : ControlResponse
    {
        [JsonProperty("discoveredAppliances")]
        public ApplianceDetails[] DiscoveredAppliances { get; set; }
    }
}
