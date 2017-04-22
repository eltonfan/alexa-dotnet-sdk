using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.System
{
    /// <summary>
    /// Indicates a successful or failed health check. The expected response to a HealthCheckRequest, and sent from the skill adapter to the Smart Home Skill API.
    /// </summary>
    public class HealthCheckResponse : MessagePayload
    {
        /// <summary>
        /// Indicates whether the skill adapter is online and receiving requests.
        /// </summary>
        public bool isHealthy { get; set; }
        /// <summary>
        /// Non-formatted description of skill adapter state.
        /// </summary>
        public string description { get; set; }
    }
    /*
     * {
        "header": {
            "messageId": "f9905dc8-b861-4912-bcf7-5b90f62b3a71",
            "name": "HealthCheckResponse",
            "namespace": "Alexa.ConnectedHome.System",
            "payloadVersion": "2"
        },
        "payload": {
            "description": "The system is currently healthy",
            "isHealthy": true
        }
    }*/
}
