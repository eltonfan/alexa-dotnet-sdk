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
}
