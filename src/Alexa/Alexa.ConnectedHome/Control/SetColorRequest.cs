using Elton.ConnectedHome;
using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class SetColorRequest : ControlRequest
    {
        [JsonProperty("color")]
        public ColorState Color { get; set; }
    }
}
