using Newtonsoft.Json;
using System;

namespace Alexa.ConnectedHome.Query
{
    public class GetLockStateResponse : MessagePayload
    {
        [JsonProperty("lockState")]
        public string LockState { get; set; }
        [JsonProperty("applianceResponseTimestamp")]
        public DateTime ApplianceResponseTimestamp { get; set; }
    }
}