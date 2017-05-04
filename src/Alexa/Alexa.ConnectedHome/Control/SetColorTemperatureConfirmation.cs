using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class SetColorTemperatureConfirmation : ControlResponse
    {
        [JsonProperty("achievedState")]
        public ColorTemperatureAchievedState AchievedState { get; set; }
    }
}
