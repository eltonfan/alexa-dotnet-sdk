using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class SetColorTemperatureConfirmation : MessagePayload
    {
        [JsonProperty("achievedState")]
        public ColorTemperatureAchievedState AchievedState { get; set; }
    }
}
