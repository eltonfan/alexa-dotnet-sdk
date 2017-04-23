using Newtonsoft.Json;
using System.Collections.Generic;

namespace Alexa.ConnectedHome.Discovery
{
    [JsonObject]
    public class DiscoverAppliancesResponse : MessagePayload
    {
        public Appliance[] discoveredAppliances { get; set; }
    }
}
