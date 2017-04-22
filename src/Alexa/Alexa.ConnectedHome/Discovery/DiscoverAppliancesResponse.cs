using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    [JsonObject]
    public class DiscoverAppliancesResponse : MessagePayload
    {
        public Appliance[] discoveredAppliances { get; set; }
    }
        /*
{
    "header": {
        "messageId": "ff746d98-ab02-4c9e-9d0d-b44711658414",
        "name": "DiscoverAppliancesResponse",
        "namespace": "Alexa.ConnectedHome.Discovery",
        "payloadVersion": "2"
    },
    "payload": {
        "discoveredAppliances": [
            {
                "actions": [
                    "incrementTargetTemperature",
                    "decrementTargetTemperature",
                    "setTargetTemperature"
                ],
                "additionalApplianceDetails": {
                    "extraDetail1": "optionalDetailForSkillAdapterToReferenceThisDevice",
                    "extraDetail2": "There can be multiple entries",
                    "extraDetail3": "but they should only be used for reference purposes.",
                    "extraDetail4": "This is not a suitable place to maintain current device state"
                },
                "applianceId": "uniqueThermostatDeviceId",
                "friendlyDescription": "descriptionThatIsShownToCustomer",
                "friendlyName": " Bedroom Thermostat",
                "isReachable": true,
                "manufacturerName": "yourManufacturerName",
                "modelName": "fancyThermostat",
                "version": "your software version number here."
            },
            {
                "actions": [
                    "incrementPercentage",
                    "decrementPercentage",
                    "setPercentage",
                    "turnOn",
                    "turnOff"
                ],
                "additionalApplianceDetails": {},
                "applianceId": "uniqueLightDeviceId",
                "friendlyDescription": "descriptionThatIsShownToCustomer",
                "friendlyName": "Living Room",
                "isReachable": true,
                "manufacturerName": "yourManufacturerName",
                "modelName": "fancyLight",
                "version": "your software version number here."
            }
        ]
    }
}
         */
}
