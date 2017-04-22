using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    public class DecrementPercentageRequest : MessagePayload
    {
        public ControlParameter deltaPercentage { get; set; }
    }
    /*
     * 
      {
        "header": {
            "messageId": "7048c18d-4141-4871-bf0e-da3e54dee3f7",
            "name": " DecrementPercentageRequest",
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
                "value": 20.0
            }
        }
    }

     */
}
