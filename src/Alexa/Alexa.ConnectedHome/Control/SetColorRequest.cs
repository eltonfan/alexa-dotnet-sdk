using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class LightColor
    {
        [JsonProperty("hue")]
        public float Hue { get; set; }
        [JsonProperty("saturation")]
        public float Saturation { get; set; }
        [JsonProperty("brightness")]
        public float Brightness { get; set; }
    }

    public class SetColorRequest : ControlRequest
    {
        [JsonProperty("color")]
        public LightColor Color { get; set; }
    }
}
