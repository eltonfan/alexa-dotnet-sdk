using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    public class SetPercentageRequest : ControlRequest
    {
        public ControlParameter percentageState { get; set; }
    }
    /*
     *  {
        "header": {
            "messageId": "95872301-4ff6-4146-b3a4-ae84c760c13e",
            "name": " SetPercentageRequest",
            "namespace": "Alexa.ConnectedHome.Control",
            "payloadVersion": "2"
        },
        "payload": {
            "accessToken": "[OAuth Token here]",
            "appliance": {
                "additionalApplianceDetails": {},
                "applianceId": "[Device ID for Cinema Room Light]"
            },
            "percentageState": {
                "value": 50.0
            }
        }
    }
*/
}
