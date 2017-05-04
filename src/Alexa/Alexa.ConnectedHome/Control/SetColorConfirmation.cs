using Elton.ConnectedHome;
using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class ColorAchievedState
    {
        [JsonProperty("color")]
        public ColorState Color { get; set; }
    }

    public class SetColorConfirmation : ControlResponse
    {
        [JsonProperty("achievedState")]
        public ColorAchievedState AchievedState { get; set; }
    }
}
