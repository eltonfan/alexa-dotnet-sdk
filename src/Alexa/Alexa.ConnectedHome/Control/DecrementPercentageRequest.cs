using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class DecrementPercentageRequest : ControlRequest
    {
        [JsonProperty("deltaPercentage")]
        public ControlParameter DeltaPercentage { get; set; }
    }
}
