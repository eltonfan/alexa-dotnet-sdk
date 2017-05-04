using Newtonsoft.Json;
using System;

namespace Alexa.ConnectedHome.Query
{
    public class GetTemperatureReadingResponse : ControlResponse
    {
        [JsonProperty("temperatureReading")]
        public ControlParameter<float> TemperatureReading { get; set; }
        [JsonProperty("applianceResponseTimestamp")]
        public DateTime ApplianceResponseTimestamp { get; set; }
    }
}
