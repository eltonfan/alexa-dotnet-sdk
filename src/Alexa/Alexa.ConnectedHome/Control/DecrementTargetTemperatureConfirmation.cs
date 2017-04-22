using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    public class DecrementTargetTemperatureConfirmation : MessagePayload
    {
        public ControlParameter targetTemperature { get; set; }
        public ControlParameter temperatureMode { get; set; }
        public TemperatureState previousState { get; set; }
    }
/*
  {
        "header": {
            "messageId": "8fab15be-c75a-4d49-b9c3-2dacc24b4c23",
            "name": "DecrementTargetTemperatureConfirmation",
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
                "value": 27.0
            },
            "temperatureMode": {
                "value": "AUTO"
            }
        }
    }
*/
}
