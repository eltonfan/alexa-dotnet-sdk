using Newtonsoft.Json;
using System.Collections.Generic;

namespace Alexa.ConnectedHome
{
    public abstract class ControlRequest : MessagePayload
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("appliance")]
        public Appliance Appliance { get; set; }
    }
}
