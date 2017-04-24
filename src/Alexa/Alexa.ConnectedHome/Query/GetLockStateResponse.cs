using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Alexa.ConnectedHome.Query
{
    public class GetLockStateResponse : MessagePayload
    {
        [JsonProperty("lockState"), JsonConverter(typeof(StringEnumConverter))]
        public ApplianceLockState LockState { get; set; }
        [JsonProperty("applianceResponseTimestamp")]
        public DateTime ApplianceResponseTimestamp { get; set; }
    }
}