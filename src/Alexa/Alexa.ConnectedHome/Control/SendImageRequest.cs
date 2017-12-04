using Elton.ConnectedHome;
using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class SendImageRequest : ControlRequest
    {
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
    }
}
