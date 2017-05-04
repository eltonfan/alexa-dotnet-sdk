using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class ColorTemperatureAchievedState
    {
        [JsonProperty("colorTemperature")]
        public ControlParameter<int> ColorTemperature { get; set; }
    }

    public class DecrementColorTemperatureConfirmation : ControlResponse
    {
        [JsonProperty("achievedState")]
        public ColorTemperatureAchievedState AchievedState { get; set; }
    }
}
