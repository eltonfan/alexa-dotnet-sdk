using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Elton.ConnectedHome
{
    public enum ActionType : byte
    {
        //On/Off Messages
        [EnumMember(Value = "turnOn")]
        TurnOn,
        [EnumMember(Value = "turnOff")]
        TurnOff,

        //Tunable Lighting Control Messages
        [EnumMember(Value = "setColor")]
        SetColor,
        [EnumMember(Value = "setColorTemperature")]
        SetColorTemperature,
        [EnumMember(Value = "incrementColorTemperature")]
        IncrementColorTemperature,
        [EnumMember(Value = "decrementColorTemperature")]
        DecrementColorTemperature,

        //Door Lock Control and Query Messages 
        [EnumMember(Value = "getLockState")]
        GetLockState,
        [EnumMember(Value = "setLockState")]
        SetLockState,

        //Temperature Control and Query Messages
        [EnumMember(Value = "getTemperatureReading")]
        GetTemperatureReading,
        [EnumMember(Value = "getTargetTemperature")]
        GetTargetTemperature,
        [EnumMember(Value = "setTargetTemperature")]
        SetTargetTemperature,
        [EnumMember(Value = "incrementTargetTemperature")]
        IncrementTargetTemperature,
        [EnumMember(Value = "decrementTargetTemperature")]
        DecrementTargetTemperature,

        //Percentage Messages
        [EnumMember(Value = "setPercentage")]
        SetPercentage,
        [EnumMember(Value = "incrementPercentage")]
        IncrementPercentage,
        [EnumMember(Value = "decrementPercentage")]
        DecrementPercentage,

        //Send Message
        [EnumMember(Value = "sendText")]
        SendText,
        [EnumMember(Value = "sendImage")]
        SendImage,
    }
}
