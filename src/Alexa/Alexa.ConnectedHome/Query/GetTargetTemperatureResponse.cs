using Newtonsoft.Json;
using System;

namespace Alexa.ConnectedHome.Query
{
    public class GetTargetTemperatureResponse : ControlResponse
    {
        [JsonProperty("targetTemperature")]
        public ControlParameter<float> TargetTemperature { get; set; }
        [JsonProperty("applianceResponseTimestamp")]
        public DateTime ApplianceResponseTimestamp { get; set; }
        [JsonProperty("temperatureMode")]
        public TemperatureModeData TemperatureMode { get; set; }
    }
}
