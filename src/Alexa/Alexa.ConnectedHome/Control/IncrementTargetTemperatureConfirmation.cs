using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    public class IncrementTargetTemperatureConfirmation : MessagePayload
    {
        public ControlParameter targetTemperature { get; set; }
        public ControlParameter temperatureMode { get; set; }
        public TemperatureState previousState { get; set; }
    }
    /*
     *  {
        "header": {
            "messageId": "780013dd-99d0-4c69-9e35-db0457f9f2a7",
            "name": "IncrementTargetTemperatureConfirmation",
            "namespace": "Alexa.ConnectedHome.Control",
            "payloadVersion": "2"
        },
        "payload": {
            "previousState": {
                "mode": {
                    "value": "AUTO"
                },
                "targetTemperature": {
                    "value": 21.0
                }
            },
            "targetTemperature": {
                "value": 25.0
            },
            "temperatureMode": {
                "value": "AUTO"
            }
        }
    }
*/
}
