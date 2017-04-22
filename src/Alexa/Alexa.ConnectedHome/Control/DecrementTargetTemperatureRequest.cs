using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    public class DecrementTargetTemperatureRequest : MessagePayload
    {
        public ControlParameter deltaTemperature { get; set; }
    }
    /*
      {
      "header": {
        "namespace": "Alexa.ConnectedHome.Control",
        "name": "DecrementTargetTemperatureRequest",
        "payloadVersion": "2",
        "messageId": "23624201-23a5-44c3-8fdc-ec6c4b6c3df8"
      },
      "payload": {
        "accessToken": "[OAuth Token here]",
        "appliance": {
          "applianceId": "[Device ID for Bedroom Thermostat]",
          "additionalApplianceDetails": {
            "extraDetail1": "optionalDetailForSkillAdapterToReferenceThisDevice",
            "extraDetail2": "There can be multiple entries",
            "extraDetail3": "but they should only be used for reference purposes.",
            "extraDetail4": "This is not a suitable place to maintain current device state"
          }
        },
        " deltaTemperature": {
          "value": 1
        }
      }
    }
*/
}
