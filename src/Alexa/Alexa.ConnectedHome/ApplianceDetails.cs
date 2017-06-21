using Elton.ConnectedHome;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Alexa.ConnectedHome
{
    [JsonObject]
    public class ApplianceDetails
    {
        [JsonProperty("actions", ItemConverterType = typeof(StringEnumConverter))]
        public ActionType[] Actions { get; set; }
        [JsonProperty("additionalApplianceDetails")]
        public Dictionary<string, string> AdditionalApplianceDetails { get; set; }
        [JsonProperty("applianceId")]
        public string ApplianceId { get; set; }
        [JsonProperty("friendlyDescription")]
        public string FriendlyDescription { get; set; }
        [JsonProperty("friendlyName")]
        public string FriendlyName { get; set; }
        [JsonProperty("isReachable")]
        public bool IsReachable { get; set; }
        [JsonProperty("manufacturerName")]
        public string ManufacturerName { get; set; }
        [JsonProperty("modelName")]
        public string ModelName { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }

        public override string ToString()
        {
            return $"Appliance {FriendlyName} (id:{ApplianceId}, model:{ModelName}, desc:{FriendlyDescription})";
        }
    }
}
