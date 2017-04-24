using Alexa.ConnectedHome;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elton.ConnectedHome.Messaging
{
    public class EventReport : ControlRequest
    {
        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }


        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        public EventReport() { }
        public EventReport(Guid deviceId, string name, string desc, Dictionary<string, string> data, DateTime timestamp)
        {
            this.Appliance = new Appliance
            {
                ApplianceId = deviceId.ToString("N").ToLower(),
            };
            this.EventName = name;
            this.Description = desc;
            this.Data = data;
            this.Timestamp = timestamp;
        }
    }
}
