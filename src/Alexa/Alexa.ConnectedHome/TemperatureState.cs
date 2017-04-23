using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.ConnectedHome
{
    public class TemperatureState
    {
        [JsonProperty("targetTemperature")]
        public ControlParameter<float> TargetTemperature { get; set; }
        [JsonProperty("mode")]
        public ControlParameter<string> Mode { get; set; }

        public TemperatureState() { }

        public TemperatureState(float targetTemperature, string mode)
        {
            this.TargetTemperature = new ControlParameter<float>(targetTemperature);
            this.Mode = new ControlParameter<string>(mode);
        }
    }
}
