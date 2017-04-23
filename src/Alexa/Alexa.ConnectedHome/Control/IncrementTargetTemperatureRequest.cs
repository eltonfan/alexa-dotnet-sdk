using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class IncrementTargetTemperatureRequest : ControlRequest
    {
        [JsonProperty("deltaTemperature")]
        public ControlParameter DeltaTemperature { get; set; }
    }
}
