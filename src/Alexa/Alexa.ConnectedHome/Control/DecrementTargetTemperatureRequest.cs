using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class DecrementTargetTemperatureRequest : ControlRequest
    {
        [JsonProperty("deltaTemperature")]
        public ControlParameter DeltaTemperature { get; set; }
    }
}
