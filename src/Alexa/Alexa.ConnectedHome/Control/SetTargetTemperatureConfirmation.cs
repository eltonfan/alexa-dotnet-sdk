using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    public class TemperatureState
    {
        public ControlParameter targetTemperature { get; set; }
        public ControlParameter mode { get; set; }
    }


    public class SetTargetTemperatureConfirmation : MessagePayload
    {
        public ControlParameter targetTemperature { get; set; }
        public ControlParameter temperatureMode { get; set; }
        public TemperatureState previousState { get; set; }
    }
/*
{
    "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"SetTargetTemperatureConfirmation",
        "payloadVersion":"2",
        "messageId":"cc36e80c-6357-41e0-9dd4-b76cb3a394e3"
    },
    "payload":{
        "targetTemperature":{
            "value":25.0
        },
        "temperatureMode":{
            "value":"AUTO"
        },
        "previousState":{
            "targetTemperature":{
                "value":21.0
            },
            "mode":{
                "value":"AUTO"
            }
        }
    }
}
*/
}
