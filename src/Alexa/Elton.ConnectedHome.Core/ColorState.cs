using Newtonsoft.Json;

namespace Elton.ConnectedHome
{
    public class ColorState
    {
        [JsonProperty("hue")]
        public float Hue { get; set; }
        [JsonProperty("saturation")]
        public float Saturation { get; set; }
        [JsonProperty("brightness")]
        public float Brightness { get; set; }

        public ColorState() { }

        public ColorState(float hue, float saturation, float brightness)
        {
            this.Hue = hue;
            this.Saturation = saturation;
            this.Brightness = brightness;
        }
    }
}