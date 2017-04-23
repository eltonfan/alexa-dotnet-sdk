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
}
