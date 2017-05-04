using Elton.ConnectedHome;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.ConnectedHome
{
    public class TemperatureModeData
    {
        [JsonProperty("value"), JsonConverter(typeof(StringEnumConverter))]
        public TemperatureMode Value { get; set; }
        [JsonProperty("friendlyName")]
        public string FriendlyName { get; set; }

        public TemperatureModeData() { }

        public TemperatureModeData(TemperatureMode value, string friendlyName)
        {
            this.Value = value;
            this.FriendlyName = friendlyName;
        }
    }
}
