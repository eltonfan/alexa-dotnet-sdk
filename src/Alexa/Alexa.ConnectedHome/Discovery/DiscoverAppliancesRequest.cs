using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Discovery
{
    [JsonObject]
    public class DiscoverAppliancesRequest : MessagePayload
    {
        [JsonProperty("accessToken")]
        public string accessToken { get; set; }
    }
    /*
{
    "header": {
        "messageId": "6d6d6e14-8aee-473e-8c24-0d31ff9c17a2",
        "name": "DiscoverAppliancesRequest",
        "namespace": "Alexa.ConnectedHome.Discovery",
        "payloadVersion": "2"
    },
    "payload": {
        "accessToken": "*OAuth Token here*"
    }
}
     */
}
