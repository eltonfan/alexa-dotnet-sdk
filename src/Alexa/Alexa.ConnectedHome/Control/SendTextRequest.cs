using Elton.ConnectedHome;
using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class SendTextRequest : ControlRequest
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
