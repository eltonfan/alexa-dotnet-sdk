using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.ConnectedHome.Control
{
    public class SetLockStateRequest : ControlRequest
    {
        [JsonProperty("lockState"), JsonConverter(typeof(StringEnumConverter))]
        public ApplianceLockState LockState { get; set; }
    }
}
