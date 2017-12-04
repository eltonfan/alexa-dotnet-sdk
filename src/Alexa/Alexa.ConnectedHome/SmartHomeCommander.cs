using Elton.ConnectedHome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome
{
    public abstract class AbstractSmartHomeCommander : ISmartHomeCommander
    {
        protected virtual void Log(LogLevel level, string format, params object[] arguments)
        {
            Console.WriteLine(level.ToString().ToUpper() + ": " + string.Format(format, arguments));
        }
        protected virtual void LogDebug(string format, params object[] arguments)
        {
            Log(LogLevel.Debug, format, arguments);
        }
        protected virtual void LogInfo(string format, params object[] arguments)
        {
            Log(LogLevel.Info, format, arguments);
        }
        protected virtual void LogWarn(string format, params object[] arguments)
        {
            Log(LogLevel.Warn, format, arguments);
        }
        protected virtual void LogError(string format, params object[] arguments)
        {
            Log(LogLevel.Error, format, arguments);
        }

        protected abstract MessagePayload ProgressMessage(MessagePayload request);


        public ApplianceDetails[] DiscoverAppliances(string accessToken)
        {
            LogInfo("Action: DiscoverAppliances");

            var request = new Discovery.DiscoverAppliancesRequest
            {
                AccessToken = accessToken,
            };

            var response = ProgressMessage(request) as Discovery.DiscoverAppliancesResponse;
            return response.DiscoveredAppliances;
        }

        //On/Off Messages
        public void TurnOn(string accessToken, Appliance appliance)
        {
            LogInfo("Action: TurnOn");

            var request = new Control.TurnOnRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
            };

            var response = ProgressMessage(request) as Control.TurnOnConfirmation;
        }

        public void TurnOff(string accessToken, Appliance appliance)
        {
            LogInfo("Action: TurnOff");

            var request = new Control.TurnOffRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
            };

            var response = ProgressMessage(request) as Control.TurnOffConfirmation;
        }

        //Tunable Lighting Control Messages

        public ColorState SetColor(string accessToken, Appliance appliance, ColorState color)
        {
            LogInfo("Action: SetColor");

            var request = new Control.SetColorRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
                 Color = color,
            };

            var response = ProgressMessage(request) as Control.SetColorConfirmation;
            return response.AchievedState.Color;
        }

        public int SetColorTemperature(string accessToken, Appliance appliance, int colorTemperature)
        {
            LogInfo("Action: SetColorTemperature");

            var request = new Control.SetColorTemperatureRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
                 ColorTemperature = new ControlParameter<int>(colorTemperature),
            };

            var response = ProgressMessage(request) as Control.SetColorTemperatureConfirmation;
            return response.AchievedState.ColorTemperature.Value;
        }


        public int IncrementColorTemperature(string accessToken, Appliance appliance)
        {
            LogInfo("Action: IncrementColorTemperature");

            var request = new Control.IncrementColorTemperatureRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
            };

            var response = ProgressMessage(request) as Control.IncrementColorTemperatureConfirmation;
            return response.AchievedState.ColorTemperature.Value;
        }

        public int DecrementColorTemperature(string accessToken, Appliance appliance)
        {
            LogInfo("Action: DecrementColorTemperature");

            var request = new Control.DecrementColorTemperatureRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
            };

            var response = ProgressMessage(request) as Control.DecrementColorTemperatureConfirmation;
            return response.AchievedState.ColorTemperature.Value;
        }

        //Door Lock Control and Query Messages 

        public LockState GetLockState(string accessToken, Appliance appliance, out DateTime applianceResponseTimestamp)
        {
            LogInfo("Action: GetLockState");

            var request = new Query.GetLockStateRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
            };

            var response = ProgressMessage(request) as Query.GetLockStateResponse;
            applianceResponseTimestamp = response.ApplianceResponseTimestamp;
            return response.LockState;
        }

        public LockState SetLockState(string accessToken, Appliance appliance, LockState lockState)
        {
            LogInfo("Action: SetLockState");

            var request = new Control.SetLockStateRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
                 LockState = lockState,
            };

            var response = ProgressMessage(request) as Control.SetLockStateConfirmation;
            return response.LockState;
        }

        //Temperature Control and Query Messages
        public float GetTemperatureReading(string accessToken, Appliance appliance, out DateTime applianceResponseTimestamp)
        {
            LogInfo("Action: GetTemperatureReading");

            var request = new Query.GetTemperatureReadingRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
            };

            var response = ProgressMessage(request) as Query.GetTemperatureReadingResponse;
            applianceResponseTimestamp = response.ApplianceResponseTimestamp;
            return response.TemperatureReading.Value;
        }

        public void GetTargetTemperature(string accessToken, Appliance appliance, out float targetTemperature, out TemperatureModeData temperatureMode, out DateTime applianceResponseTimestamp)
        {
            LogInfo("Action: GetTargetTemperature");

            var request = new Query.GetTargetTemperatureRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
            };

            var response = ProgressMessage(request) as Query.GetTargetTemperatureResponse;
            targetTemperature = response.TargetTemperature.Value;
            temperatureMode = response.TemperatureMode;
            applianceResponseTimestamp = response.ApplianceResponseTimestamp;
        }

        public void SetTargetTemperature(string accessToken, Appliance appliance, float targetTemperature, out TemperatureState currentState, out TemperatureState previousState)
        {
            LogInfo("Action: SetTargetTemperature");

            var request = new Control.SetTargetTemperatureRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
                TargetTemperature = new ControlParameter(targetTemperature),
            };

            var response = ProgressMessage(request) as Control.SetTargetTemperatureConfirmation;
            currentState = new TemperatureState
            {
                TargetTemperature = response.TargetTemperature,
                Mode = response.TemperatureMode,
            };
            previousState = response.PreviousState;
        }

        public void IncrementTargetTemperature(string accessToken, Appliance appliance, float deltaTemperature, out TemperatureState currentState, out TemperatureState previousState)
        {
            LogInfo("Action: IncrementTargetTemperature");

            var request = new Control.IncrementTargetTemperatureRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
                DeltaTemperature = new ControlParameter(deltaTemperature),
            };

            var response = ProgressMessage(request) as Control.IncrementTargetTemperatureConfirmation;
            currentState = new TemperatureState
            {
                TargetTemperature = response.TargetTemperature,
                Mode = response.TemperatureMode,
            };
            previousState = response.PreviousState;
        }

        public void DecrementTargetTemperature(string accessToken, Appliance appliance, float deltaTemperature, out TemperatureState currentState, out TemperatureState previousState)
        {
            LogInfo("Action: DecrementTargetTemperature");

            var request = new Control.DecrementTargetTemperatureRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
                DeltaTemperature = new ControlParameter(deltaTemperature),
            };

            var response = ProgressMessage(request) as Control.DecrementTargetTemperatureConfirmation;
            currentState = new TemperatureState
            {
                TargetTemperature = response.TargetTemperature,
                Mode = response.TemperatureMode,
            };
            previousState = response.PreviousState;
        }

        //Percentage Messages

        public void SetPercentage(string accessToken, Appliance appliance, float percentage)
        {
            LogInfo("Action: SetPercentage");

            var request = new Control.SetPercentageRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
                PercentageState = new ControlParameter(percentage),
            };

            var response = ProgressMessage(request) as Control.SetPercentageConfirmation;
        }

        public void IncrementPercentage(string accessToken, Appliance appliance, float deltaPercentage)
        {
            LogInfo("Action: IncrementPercentage");

            var request = new Control.IncrementPercentageRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
                DeltaPercentage = new ControlParameter(deltaPercentage),
            };

            var response = ProgressMessage(request) as Control.IncrementPercentageConfirmation;
        }

        public void DecrementPercentage(string accessToken, Appliance appliance, float deltaPercentage)
        {
            LogInfo("Action: DecrementPercentage");

            var request = new Control.DecrementPercentageRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
                DeltaPercentage = new ControlParameter(deltaPercentage),
            };

            var response = ProgressMessage(request) as Control.DecrementPercentageConfirmation;
        }

        //Health Check Messages
        public bool HealthCheck(long initiationTimestamp, out string description)
        {
            LogInfo("Action: HealthCheck");

            var request = new System.HealthCheckRequest
            {
                InitiationTimestamp = initiationTimestamp.ToString(),
            };

            var response = ProgressMessage(request) as System.HealthCheckResponse;
            description = response.Description;
            return response.IsHealthy;
        }

        //Send Message
        public void SendText(string accessToken, Appliance appliance, string text)
        {
            LogInfo($"Action: SendText(imageUrl:\"{text}\")");
            var request = new Control.SendTextRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
                Text = text,
            };
            var response = ProgressMessage(request) as Control.SendTextConfirmation;
        }
        public void SendImage(string accessToken, Appliance appliance, string imageUrl)
        {
            LogInfo($"Action: SendImage(imageUrl:\"{imageUrl}\")");
            var request = new Control.SendImageRequest
            {
                AccessToken = accessToken,
                Appliance = appliance,
                ImageUrl = imageUrl,
            };
            var response = ProgressMessage(request) as Control.SendImageConfirmation;
        }
    }
}
