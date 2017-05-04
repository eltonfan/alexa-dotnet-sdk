using Elton.ConnectedHome;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Alexa.ConnectedHome.Control
{
    public class SetLockStateConfirmation : ControlResponse
    {
        [JsonProperty("lockState"), JsonConverter(typeof(StringEnumConverter))]
        public LockState LockState { get; set; }
    }
}
