using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome
{
    /// <summary>
    /// The skill adapter directive.
    /// </summary>
    public class Message
    {
        public MessageHeader Header { get; set; }
        public MessagePayload Payload { get; set; }
    }
}
