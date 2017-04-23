using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class TemperatureState
    {
        [JsonProperty("targetTemperature")]
        public ControlParameter TargetTemperature { get; set; }
        [JsonProperty("mode")]
        public ControlParameter Mode { get; set; }
    }


    public class SetTargetTemperatureConfirmation : MessagePayload
    {
        [JsonProperty("targetTemperature")]
        public ControlParameter TargetTemperature { get; set; }
        [JsonProperty("temperatureMode")]
        public ControlParameter TemperatureMode { get; set; }
        [JsonProperty("previousState")]
        public TemperatureState PreviousState { get; set; }
    }
}
