using Newtonsoft.Json;
using System;

namespace Alexa.ConnectedHome.Control
{
    public class SetLockStateConfirmation : MessagePayload
    {
        [JsonProperty("lockState")]
        public string LockState { get; set; }
    }
}
