using Newtonsoft.Json;
using System.Collections.Generic;

namespace Alexa.ConnectedHome.Discovery
{
    [JsonObject]
    public class Appliance
    {
        public string[] actions { get; set; }
        public Dictionary<string, string> additionalApplianceDetails { get; set; }
        public string applianceId { get; set; }
        public string friendlyDescription { get; set; }
        public string friendlyName { get; set; }
        public bool isReachable { get; set; }
        public string manufacturerName { get; set; }
        public string modelName { get; set; }
        public string version { get; set; }
    }
}
