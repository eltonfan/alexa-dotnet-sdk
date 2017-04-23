using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class IncrementPercentageRequest : ControlRequest
    {
        [JsonProperty("deltaPercentage")]
        public ControlParameter DeltaPercentage { get; set; }
    }
}
