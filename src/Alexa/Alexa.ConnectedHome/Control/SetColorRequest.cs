using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class SetColorRequest : ControlRequest
    {
        [JsonProperty("color")]
        public LightColor Color { get; set; }
    }
}
