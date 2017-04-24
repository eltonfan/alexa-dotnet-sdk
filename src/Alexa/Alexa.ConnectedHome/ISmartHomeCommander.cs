using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome
{
    public interface ISmartHomeCommander
    {
        //On/Off Messages
        void TurnOn(string accessToken, Appliance appliance);
        void TurnOff(string accessToken, Appliance appliance);
        //Tunable Lighting Control Messages
        LightColor SetColor(string accessToken, Appliance appliance, LightColor color);
        int SetColorTemperature(string accessToken, Appliance appliance, int colorTemperature);
        int IncrementColorTemperature(string accessToken, Appliance appliance);
        int DecrementColorTemperature(string accessToken, Appliance appliance);
        //Door Lock Control and Query Messages 
        ApplianceLockState GetLockState(string accessToken, Appliance appliance, out DateTime applianceResponseTimestamp);
        ApplianceLockState SetLockState(string accessToken, Appliance appliance, ApplianceLockState lockState);
        //Temperature Control and Query Messages
        float GetTemperatureReading(string accessToken, Appliance appliance, out DateTime applianceResponseTimestamp);
        void GetTargetTemperature(string accessToken, Appliance appliance,
            out float targetTemperature, out TemperatureModeData temperatureMode, out DateTime applianceResponseTimestamp);
        void SetTargetTemperature(string accessToken, Appliance appliance, float targetTemperature,
            out TemperatureState currentState, out TemperatureState previousState);
        void IncrementTargetTemperature(string accessToken, Appliance appliance, float deltaTemperature,
            out TemperatureState currentState, out TemperatureState previousState);
        void DecrementTargetTemperature(string accessToken, Appliance appliance, float deltaTemperature,
            out TemperatureState currentState, out TemperatureState previousState);
        //Percentage Messages
        void SetPercentage(string accessToken, Appliance appliance, float percentage);
        void IncrementPercentage(string accessToken, Appliance appliance, float deltaPercentage);
        void DecrementPercentage(string accessToken, Appliance appliance, float deltaPercentage);
        //Health Check Messages
        bool HealthCheck(long initiationTimestamp, out string description);
    }
}
