using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    public class SetTargetTemperatureRequest : ControlRequest
    {
        public ControlParameter targetTemperature { get; set; }
    }
/*
    {
        "header": {
            "messageId": "b6602211-b4b3-4960-b063-f7e3967c00c4",
            "name": "SetTargetTemperatureRequest",
            "namespace": "Alexa.ConnectedHome.Control",
            "payloadVersion": "2"
        },
        "payload": {
            "accessToken": "[OAuth Token here]",
            "appliance": {
                "additionalApplianceDetails": {
                    "extraDetail1": "optionalDetailForSkillAdapterToReferenceThisDevice",
                    "extraDetail2": "There can be multiple entries",
                    "extraDetail3": "but they should only be used for reference purposes.",
                    "extraDetail4": "This is not a suitable place to maintain current device state"
                },
                "applianceId": "[Device ID for Living Room Thermostat]"
            },
            "targetTemperature": {
                "value": 25.0
            }
        }
    }
*/
}
