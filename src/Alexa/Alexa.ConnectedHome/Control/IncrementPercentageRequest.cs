using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    public class IncrementPercentageRequest : ControlRequest
    {
        public ControlParameter deltaPercentage { get; set; }
    }
    /*
     * 
     {
        "header": {
            "messageId": "a0c739b9-4c12-48c9-88c7-fc2e1f051b0b",
            "name": "IncrementPercentageRequest",
            "namespace": "Alexa.ConnectedHome.Control",
            "payloadVersion": "2"
        },
        "payload": {
            "accessToken": "[OAuth Token here]",
            "appliance": {
                "additionalApplianceDetails": {},
                "applianceId": "[Device ID for Cinema Room Light]"
            },
            "deltaPercentage": {
                "value": 10.0
            }
        }
    }

     */
}
