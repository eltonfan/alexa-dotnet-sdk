using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.System
{
    /// <summary>
    /// Requests the availability of the skill adapter. These are periodically sent by the Smart Home Skill API to the skill adapter.
    /// </summary>
    public class HealthCheckRequest : MessagePayload
    {
        /// <summary>
        /// A timestamp, in milliseconds since
        /// January 1, 1970, which indicates
        /// when the health check was sent.
        /// </summary>
        public string initiationTimestamp { get; set; }
    }
    /*
  {
        "header": {
            "messageId": "243550dc-5f95-4ae4-ad43-4e1e7cb037fd",
            "name": " HealthCheckRequest",
            "namespace": "Alexa.ConnectedHome.System",
            "payloadVersion": "2"
        },
        "payload": {
            "initiationTimestamp": "1435302567000"
        }
    }
     */
}
