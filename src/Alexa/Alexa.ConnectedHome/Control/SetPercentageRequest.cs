using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class SetPercentageRequest : ControlRequest
    {
        [JsonProperty("percentageState")]
        public ControlParameter PercentageState { get; set; }
    }
}
