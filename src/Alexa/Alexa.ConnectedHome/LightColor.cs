using Newtonsoft.Json;

namespace Alexa.ConnectedHome
{
    public class LightColor
    {
        [JsonProperty("hue")]
        public float Hue { get; set; }
        [JsonProperty("saturation")]
        public float Saturation { get; set; }
        [JsonProperty("brightness")]
        public float Brightness { get; set; }

        public LightColor() { }

        public LightColor(float hue, float saturation, float brightness)
        {
            this.Hue = hue;
            this.Saturation = saturation;
            this.Brightness = brightness;
        }
    }
}