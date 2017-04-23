using Newtonsoft.Json;
using System;

namespace Alexa.ConnectedHome.Query
{
    public class GetTargetTemperatureResponse : MessagePayload
    {
        [JsonProperty("targetTemperature")]
        public ControlParameter TargetTemperature { get; set; }
        [JsonProperty("applianceResponseTimestamp")]
        public DateTime ApplianceResponseTimestamp { get; set; }
        [JsonProperty("temperatureMode")]
        public TemperatureModeData TemperatureMode { get; set; }
    }
}
