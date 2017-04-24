using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class SetColorTemperatureRequest : ControlRequest
    {
        [JsonProperty("colorTemperature")]
        public ControlParameter<int> ColorTemperature { get; set; }
    }
}
