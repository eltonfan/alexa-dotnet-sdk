using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Alexa.ConnectedHome.Control
{
    public class SetLockStateConfirmation : MessagePayload
    {
        [JsonProperty("lockState"), JsonConverter(typeof(StringEnumConverter))]
        public ApplianceLockState LockState { get; set; }
    }
}
