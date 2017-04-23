using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class IncrementColorTemperatureConfirmation : MessagePayload
    {
        [JsonProperty("achievedState")]
        public ColorTemperatureAchievedState AchievedState { get; set; }
    }
}