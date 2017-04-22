using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome
{
    /// <summary>
    /// The skill adapter directive.
    /// </summary>
    [JsonObject]
    public class Message
    {
        [JsonProperty("header")]
        public MessageHeader Header { get; set; }
        [JsonProperty("payload")]
        public dynamic Payload { get; set; }
    }
}
