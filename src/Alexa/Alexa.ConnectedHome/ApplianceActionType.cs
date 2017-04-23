using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome
{
    public enum ApplianceActionType : byte
    {
        //On/Off Messages
        [JsonProperty("turnOn")]
        TurnOn,
        [JsonProperty("turnOff")]
        TurnOff,

        //Tunable Lighting Control Messages
        [JsonProperty("setColor")]
        setColor,
        [JsonProperty("setColorTemperature")]
        setColorTemperature,
        [JsonProperty("incrementColorTemperature")]
        incrementColorTemperature,
        [JsonProperty("decrementColorTemperature")]
        decrementColorTemperature,

        //Door Lock Control and Query Messages 
        [JsonProperty("getLockState")]
        getLockState,
        [JsonProperty("setLockState")]
        setLockState,

        //Temperature Control and Query Messages
        [JsonProperty("getTemperatureReading")]
        getTemperatureReading,
        [JsonProperty("getTargetTemperature")]
        getTargetTemperature,
        [JsonProperty("setTargetTemperature")]
        SetTargetTemperature,
        [JsonProperty("incrementTargetTemperature")]
        IncrementTargetTemperature,
        [JsonProperty("decrementTargetTemperature")]
        DecrementTargetTemperature,

        //Percentage Messages
        [JsonProperty("setPercentage")]
        SetPercentage,
        [JsonProperty("incrementPercentage")]
        IncrementPercentage,
        [JsonProperty("decrementPercentage")]
        DecrementPercentage,
    }
}
