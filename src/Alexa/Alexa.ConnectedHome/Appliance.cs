using Newtonsoft.Json;
using System.Collections.Generic;

namespace Alexa.ConnectedHome
{
    public class Appliance
    {
        [JsonProperty("additionalApplianceDetails")]
        public Dictionary<string, string> AdditionalApplianceDetails { get; set; }
        [JsonProperty("applianceId")]
        public string ApplianceId { get; set; }
    }
}
