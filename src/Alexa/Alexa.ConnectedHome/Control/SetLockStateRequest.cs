using Newtonsoft.Json;

namespace Alexa.ConnectedHome.Control
{
    public class SetLockStateRequest : ControlRequest
    {
        [JsonProperty("lockState")]
        public string LockState { get; set; }
    }
}
