using Elton.ConnectedHome;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Alexa.ConnectedHome.Query
{
    public class GetLockStateResponse : ControlResponse
    {
        [JsonProperty("lockState"), JsonConverter(typeof(StringEnumConverter))]
        public LockState LockState { get; set; }
        [JsonProperty("applianceResponseTimestamp")]
        public DateTime ApplianceResponseTimestamp { get; set; }
    }
}