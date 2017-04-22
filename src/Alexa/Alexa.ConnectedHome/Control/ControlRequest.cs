using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    public class Appliance
    {
        public Dictionary<string, string> additionalApplianceDetails { get; set; }
        public string applianceId { get; set; }
    }

    public class ControlParameter
    {
        public object value { get; set; }
    }


    public abstract class ControlRequest : MessagePayload
    {
        public string accessToken { get; set; }
        public Appliance appliance { get; set; }
    }

    /*
{
        "header": {
            "messageId": "01ebf625-0b89-4c4d-b3aa-32340e894688",
            "name": "TurnOnRequest",
            "namespace": "Alexa.ConnectedHome.Control",
            "payloadVersion": "2"
        },
        "payload": {
            "accessToken": "[OAuth Token here]",
            "appliance": {
                "additionalApplianceDetails": {},
                "applianceId": "[Device ID for Ceiling Fan]"
            }
        }
    }
    */
}
