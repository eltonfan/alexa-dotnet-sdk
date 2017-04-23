using Newtonsoft.Json;
using System;

namespace Alexa.ConnectedHome.Query
{
    public class TemperatureMode
    {
        [JsonProperty("value")]
        public object Value { get; set; }
        [JsonProperty("friendlyName")]
        public string FriendlyName { get; set; }
    }

    public class GetTargetTemperatureResponse : MessagePayload
    {
        [JsonProperty("targetTemperature")]
        public ControlParameter TargetTemperature { get; set; }
        [JsonProperty("applianceResponseTimestamp")]
        public DateTime ApplianceResponseTimestamp { get; set; }
        [JsonProperty("temperatureMode")]
        public TemperatureMode TemperatureMode { get; set; }
    }
}
