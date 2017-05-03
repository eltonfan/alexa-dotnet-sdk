using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alexa.ConnectedHome;
using Newtonsoft.Json;

namespace Elton.ConnectedHome.Messaging
{
    public class HeartbeatReport : MessagePayload
    {
        [JsonProperty("gatewayId")]
        public Guid GatewayId { get; set; }
        [JsonProperty("gatewayName")]
        public string GatewayName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        public HeartbeatReport() { }
        public HeartbeatReport(Guid gatewayId, string gatewayName, string description)
        {
            this.GatewayId = gatewayId;
            this.GatewayName = gatewayName;
            this.Description = description;
        }
    }
}
