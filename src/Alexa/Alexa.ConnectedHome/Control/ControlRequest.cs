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

    public class ControlParameter
    {
        [JsonProperty("value")]
        public object Value { get; set; }
    }


    public abstract class ControlRequest : MessagePayload
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("appliance")]
        public Appliance Appliance { get; set; }
    }
}
