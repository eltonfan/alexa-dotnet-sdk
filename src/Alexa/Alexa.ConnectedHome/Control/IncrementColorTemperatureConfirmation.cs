using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class IncrementColorTemperatureConfirmation : ControlResponse
    {
        [JsonProperty("achievedState")]
        public ColorTemperatureAchievedState AchievedState { get; set; }
    }
}