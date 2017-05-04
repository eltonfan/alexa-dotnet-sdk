using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class SetTargetTemperatureConfirmation : ControlResponse
    {
        [JsonProperty("targetTemperature")]
        public ControlParameter<float> TargetTemperature { get; set; }
        [JsonProperty("temperatureMode")]
        public ControlParameter<string> TemperatureMode { get; set; }
        [JsonProperty("previousState")]
        public TemperatureState PreviousState { get; set; }
    }
}
