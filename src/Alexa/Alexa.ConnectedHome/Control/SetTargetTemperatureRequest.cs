using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class SetTargetTemperatureRequest : ControlRequest
    {
        [JsonProperty("targetTemperature")]
        public ControlParameter TargetTemperature { get; set; }
    }
}
