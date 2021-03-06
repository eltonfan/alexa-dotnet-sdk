﻿using Newtonsoft.Json;

namespace Alexa.ConnectedHome.System
{
    /// <summary>
    /// Requests the availability of the skill adapter. These are periodically sent by the Smart Home Skill API to the skill adapter.
    /// </summary>
    public class HealthCheckRequest : Elton.ConnectedHome.MessagePayload
    {
        /// <summary>
        /// A timestamp, in milliseconds since
        /// January 1, 1970, which indicates
        /// when the health check was sent.
        /// </summary>
        [JsonProperty("initiationTimestamp")]
        public string InitiationTimestamp { get; set; }
    }
}
