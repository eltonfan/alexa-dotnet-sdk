using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome
{
    /// <summary>
    /// The directive header.
    /// </summary>
    [JsonObject]
    public class MessageHeader
    {
        [JsonProperty("messageId")]
        public Guid MessageId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("namespace")]
        public string Namespace { get; set; }
        [JsonProperty("payloadVersion")]
        public string PayloadVersion { get; set; } = "1";

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public string FullName
        {
            get
            {
                return string.Format("{0}.{1}", this.Namespace, this.Name);
            }
        }
    }
}