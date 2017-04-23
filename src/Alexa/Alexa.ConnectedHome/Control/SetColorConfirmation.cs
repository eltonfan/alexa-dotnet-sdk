using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class ColorAchievedState
    {
        [JsonProperty("color")]
        public LightColor Color { get; set; }
    }

    public class SetColorConfirmation : MessagePayload
    {
        [JsonProperty("achievedState")]
        public ColorAchievedState AchievedState { get; set; }
    }
}
