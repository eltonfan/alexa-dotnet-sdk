using Newtonsoft.Json;

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
        [JsonProperty("isHealthy")]
        public bool IsHealthy { get; set; }
        /// <summary>
        /// Non-formatted description of skill adapter state.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        public HealthCheckResponse() { }
        public HealthCheckResponse(bool isHealthy, string description)
        {
            this.IsHealthy = isHealthy;
            this.Description = description;
        }
    }
}
