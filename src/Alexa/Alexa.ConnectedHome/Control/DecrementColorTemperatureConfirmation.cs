using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class ColorTemperatureAchievedState
    {
        [JsonProperty("colorTemperature")]
        public ControlParameter ColorTemperature { get; set; }
    }

    public class DecrementColorTemperatureConfirmation : MessagePayload
    {
        [JsonProperty("achievedState")]
        public ColorTemperatureAchievedState AchievedState { get; set; }
    }
}