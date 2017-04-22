using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    public class IncrementTargetTemperatureRequest : MessagePayload
    {
        public ControlParameter deltaTemperature { get; set; }
    }
    /*
     * 
    {
            "header": {
                "messageId": "77ff65eb-a015-4777-99ba-6e90d200dd6c",
                "name": "IncrementTargetTemperatureRequest",
                "namespace": "Alexa.ConnectedHome.Control",
                "payloadVersion": "2"
            },
            "payload": {
                " deltaTemperature": {
                    "value": 3.6
                },
                "accessToken": "[OAuth Token here]",
                "appliance": {
                    "additionalApplianceDetails": {
                        "extraDetail1": "optionalDetailForSkillAdapterToReferenceThisDevice",
                        "extraDetail2": "There can be multiple entries",
                        "extraDetail3": "but they should only be used for reference purposes.",
                        "extraDetail4": "This is not a suitable place to maintain current device state"
                    },
                    "applianceId": "[Device ID for Bedroom Thermostat]"
                }
            }
        }

     */
}
