using Elton.ConnectedHome;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.ConnectedHome.Control
{
    public class SetLockStateRequest : ControlRequest
    {
        [JsonProperty("lockState"), JsonConverter(typeof(StringEnumConverter))]
        public LockState LockState { get; set; }
    }
}
