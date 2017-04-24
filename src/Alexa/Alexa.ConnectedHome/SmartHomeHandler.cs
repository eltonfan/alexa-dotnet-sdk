using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome
{
    public enum LogLevel
    {
        All,
        Trace,
        Debug,
        Info,
        Warn,
        Error,
        Fatal,
    }

    public abstract class AbstractSmartHomeHandler : ISmartHomeHandler
    {
        protected abstract void Log(LogLevel level, string format, params object[] arguments);

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

        protected Message ProgressMessage(string requestJsonString)
        {
            return ProgressMessage(MessageFactory.Parse(requestJsonString));
        }

        protected Message ProgressMessage(JObject requestObj)
        {
            return ProgressMessage(MessageFactory.Parse(requestObj));
        }

        protected Message ProgressMessage(Message request)
        {
            MessagePayload payload = request.Payload;
            MessagePayload response = null;

            try
            {
                //Discovery Messages
                if (payload is Discovery.DiscoverAppliancesRequest)
                    response = ProgressMessage(payload as Discovery.DiscoverAppliancesRequest);
                //On/Off Messages
                else if (payload is Control.TurnOnRequest)
                    response = ProgressMessage(payload as Control.TurnOnRequest);
                else if (payload is Control.TurnOffRequest)
                    response = ProgressMessage(payload as Control.TurnOffRequest);
                //Tunable Lighting Control Messages
                else if (payload is Control.SetColorRequest)
                    response = ProgressMessage(payload as Control.SetColorRequest);
                else if (payload is Control.SetColorTemperatureRequest)
                    response = ProgressMessage(payload as Control.SetColorTemperatureRequest);
                else if (payload is Control.IncrementColorTemperatureRequest)
                    response = ProgressMessage(payload as Control.IncrementColorTemperatureRequest);
                else if (payload is Control.DecrementColorTemperatureRequest)
                    response = ProgressMessage(payload as Control.DecrementColorTemperatureRequest);
                //Door Lock Control and Query Messages 
                else if (payload is Query.GetLockStateRequest)
                    response = ProgressMessage(payload as Query.GetLockStateRequest);
                else if (payload is Control.SetLockStateRequest)
                    response = ProgressMessage(payload as Control.SetLockStateRequest);
                //Temperature Control and Query Messages
                else if (payload is Query.GetTemperatureReadingRequest)
                    response = ProgressMessage(payload as Query.GetTemperatureReadingRequest);
                else if (payload is Query.GetTargetTemperatureRequest)
                    response = ProgressMessage(payload as Query.GetTargetTemperatureRequest);
                else if (payload is Control.SetTargetTemperatureRequest)
                    response = ProgressMessage(payload as Control.SetTargetTemperatureRequest);
                else if (payload is Control.IncrementTargetTemperatureRequest)
                    response = ProgressMessage(payload as Control.IncrementTargetTemperatureRequest);
                else if (payload is Control.DecrementTargetTemperatureRequest)
                    response = ProgressMessage(payload as Control.DecrementTargetTemperatureRequest);
                //Percentage Messages
                else if (payload is Control.SetPercentageRequest)
                    response = ProgressMessage(payload as Control.SetPercentageRequest);
                else if (payload is Control.IncrementPercentageRequest)
                    response = ProgressMessage(payload as Control.IncrementPercentageRequest);
                else if (payload is Control.DecrementPercentageRequest)
                    response = ProgressMessage(payload as Control.DecrementPercentageRequest);
                //Health Check Messages
                else if (payload is Alexa.ConnectedHome.System.HealthCheckRequest)
                    response = ProgressMessage(payload as Alexa.ConnectedHome.System.HealthCheckRequest);
                else
                    throw new NotSupportedException(string.Format("Not supported message type '{0}'.", payload.GetType().FullName));
            }
            catch (Exception ex)
            {
                response = new Control.NoSuchTargetError();
            }

            return MessageFactory.Create(response);
        }

        protected abstract ApplianceDetails[] DiscoverAppliances(string accessToken);

        //On/Off Messages
        protected abstract void TurnOn(string accessToken, Appliance appliance);
        protected abstract void TurnOff(string accessToken, Appliance appliance);
        //Tunable Lighting Control Messages
        protected abstract LightColor SetColor(string accessToken, Appliance appliance, LightColor color);
        protected abstract int SetColorTemperature(string accessToken, Appliance appliance, int colorTemperature);
        protected abstract int IncrementColorTemperature(string accessToken, Appliance appliance);
        protected abstract int DecrementColorTemperature(string accessToken, Appliance appliance);
        //Door Lock Control and Query Messages 
        protected abstract ApplianceLockState GetLockState(string accessToken, Appliance appliance, out DateTime applianceResponseTimestamp);
        protected abstract ApplianceLockState SetLockState(string accessToken, Appliance appliance, ApplianceLockState lockState);
        //Temperature Control and Query Messages
        protected abstract float GetTemperatureReading(string accessToken, Appliance appliance, out DateTime applianceResponseTimestamp);
        protected abstract void GetTargetTemperature(string accessToken, Appliance appliance,
            out float targetTemperature, out TemperatureModeData temperatureMode, out DateTime applianceResponseTimestamp);
        protected abstract void SetTargetTemperature(string accessToken, Appliance appliance, float targetTemperature,
            out TemperatureState currentState, out TemperatureState previousState);
        protected abstract void IncrementTargetTemperature(string accessToken, Appliance appliance, float deltaTemperature,
            out TemperatureState currentState, out TemperatureState previousState);
        protected abstract void DecrementTargetTemperature(string accessToken, Appliance appliance, float deltaTemperature,
            out TemperatureState currentState, out TemperatureState previousState);
        //Percentage Messages
        protected abstract void SetPercentage(string accessToken, Appliance appliance, float percentage);
        protected abstract void IncrementPercentage(string accessToken, Appliance appliance, float deltaPercentage);
        protected abstract void DecrementPercentage(string accessToken, Appliance appliance, float deltaPercentage);
        //Health Check Messages
        protected abstract bool HealthCheck(long initiationTimestamp, out string description);


        Discovery.DiscoverAppliancesResponse ProgressMessage(Discovery.DiscoverAppliancesRequest request)
        {
            LogInfo("Action: DiscoverAppliances");
            var result = DiscoverAppliances(request.AccessToken);
            return new Discovery.DiscoverAppliancesResponse
            {
                DiscoveredAppliances = result,
            };
        }

        Control.TurnOnConfirmation ProgressMessage(Control.TurnOnRequest request)
        {
            LogInfo("Action: TurnOn");
            TurnOn(request.AccessToken, request.Appliance);
            return new Control.TurnOnConfirmation { };
        }

        Control.TurnOffConfirmation ProgressMessage(Control.TurnOffRequest request)
        {
            LogInfo("Action: TurnOff");
            TurnOff(request.AccessToken, request.Appliance);
            return new Control.TurnOffConfirmation { };
        }

        Control.SetColorConfirmation ProgressMessage(Control.SetColorRequest request)
        {
            LogInfo("Action: SetColor");
            var achievedState = SetColor(request.AccessToken, request.Appliance, request.Color);
            return new Control.SetColorConfirmation
            {
                AchievedState = new Control.ColorAchievedState
                {
                    Color = achievedState,
                }
            };
        }

        Control.SetColorTemperatureConfirmation ProgressMessage(Control.SetColorTemperatureRequest request)
        {
            LogInfo("Action: SetColorTemperature");
            var achievedState = SetColorTemperature(request.AccessToken, request.Appliance, request.ColorTemperature.Value);

            return new Control.SetColorTemperatureConfirmation
            {
                AchievedState = new Control.ColorTemperatureAchievedState
                {
                    ColorTemperature = new ControlParameter<int>(achievedState),
                }
            };
        }
        Control.IncrementColorTemperatureConfirmation ProgressMessage(Control.IncrementColorTemperatureRequest request)
        {
            LogInfo("Action: IncrementColorTemperature");
            var achievedState = IncrementColorTemperature(request.AccessToken, request.Appliance);
            return new Control.IncrementColorTemperatureConfirmation
            {
                AchievedState = new Control.ColorTemperatureAchievedState
                {
                    ColorTemperature = new ControlParameter<int>(achievedState),
                }
            };

        }
        Control.DecrementColorTemperatureConfirmation ProgressMessage(Control.DecrementColorTemperatureRequest request)
        {
            LogInfo("Action: DecrementColorTemperature");
            var achievedState = DecrementColorTemperature(request.AccessToken, request.Appliance);
            return new Control.DecrementColorTemperatureConfirmation
            {
                AchievedState = new Control.ColorTemperatureAchievedState
                {
                    ColorTemperature = new ControlParameter<int>(achievedState),
                }
            };
        }

        Query.GetLockStateResponse ProgressMessage(Query.GetLockStateRequest request)
        {
            LogInfo("Action: GetLockState");
            DateTime applianceResponseTimestamp;
            var currentState = GetLockState(request.AccessToken, request.Appliance, out applianceResponseTimestamp);
            return new Query.GetLockStateResponse
            {
                LockState = currentState,
                ApplianceResponseTimestamp = applianceResponseTimestamp,
            };
        }

        Control.SetLockStateConfirmation ProgressMessage(Control.SetLockStateRequest request)
        {
            LogInfo("Action: SetLockState");
            var currentState = SetLockState(request.AccessToken, request.Appliance, request.LockState);
            return new Control.SetLockStateConfirmation
            {
                LockState = currentState,
            };
        }

        Query.GetTemperatureReadingResponse ProgressMessage(Query.GetTemperatureReadingRequest request)
        {
            LogInfo("Action: GetTemperatureReading");
            DateTime applianceResponseTimestamp;
            float temperature = GetTemperatureReading(request.AccessToken, request.Appliance, out applianceResponseTimestamp);

            return new Query.GetTemperatureReadingResponse
            {
                TemperatureReading = new ControlParameter<float>(temperature),
                ApplianceResponseTimestamp = applianceResponseTimestamp,
            };

        }

        Query.GetTargetTemperatureResponse ProgressMessage(Query.GetTargetTemperatureRequest request)
        {
            LogInfo("Action: GetTargetTemperature");
            float targetTemperature;
            TemperatureModeData temperatureMode;
            DateTime applianceResponseTimestamp;
            GetTargetTemperature(request.AccessToken, request.Appliance,
                out targetTemperature, out temperatureMode, out applianceResponseTimestamp);

            return new Query.GetTargetTemperatureResponse
            {
                TargetTemperature = new ControlParameter<float>(targetTemperature),
                ApplianceResponseTimestamp = applianceResponseTimestamp,
                TemperatureMode = temperatureMode,
            };
        }

        Control.SetTargetTemperatureConfirmation ProgressMessage(Control.SetTargetTemperatureRequest request)
        {
            LogInfo("Action: SetTargetTemperature");
            TemperatureState currentState, previousState;
            SetTargetTemperature(request.AccessToken, request.Appliance, (float)request.TargetTemperature.Value,
                out currentState, out previousState);

            return new Control.SetTargetTemperatureConfirmation
            {
                TargetTemperature = currentState.TargetTemperature,
                TemperatureMode = currentState.Mode,
                PreviousState = previousState,
            };
        }

        Control.IncrementTargetTemperatureConfirmation ProgressMessage(Control.IncrementTargetTemperatureRequest request)
        {
            LogInfo("Action: IncrementTargetTemperature");
            TemperatureState currentState, previousState;
            IncrementTargetTemperature(request.AccessToken, request.Appliance, (float)request.DeltaTemperature.Value,
                out currentState, out previousState);

            return new Control.IncrementTargetTemperatureConfirmation
            {
                TargetTemperature = currentState.TargetTemperature,
                TemperatureMode = currentState.Mode,
                PreviousState = previousState,
            };
        }

        Control.DecrementTargetTemperatureConfirmation ProgressMessage(Control.DecrementTargetTemperatureRequest request)
        {
            LogInfo("Action: DecrementTargetTemperature");
            TemperatureState currentState, previousState;
            DecrementTargetTemperature(request.AccessToken, request.Appliance, (float)request.DeltaTemperature.Value,
                out currentState, out previousState);

            return new Control.DecrementTargetTemperatureConfirmation
            {
                TargetTemperature = currentState.TargetTemperature,
                TemperatureMode = currentState.Mode,
                PreviousState = previousState,
            };
        }

        Control.SetPercentageConfirmation ProgressMessage(Control.SetPercentageRequest request)
        {
            LogInfo("Action: SetPercentage");
            SetPercentage(request.AccessToken, request.Appliance, (float)request.PercentageState.Value);
            return new Control.SetPercentageConfirmation { };
        }

        Control.IncrementPercentageConfirmation ProgressMessage(Control.IncrementPercentageRequest request)
        {
            LogInfo("Action: IncrementPercentage");
            IncrementPercentage(request.AccessToken, request.Appliance, (float)request.DeltaPercentage.Value);
            return new Control.IncrementPercentageConfirmation { };
        }

        Control.DecrementPercentageConfirmation ProgressMessage(Control.DecrementPercentageRequest request)
        {
            LogInfo("Action: DecrementPercentage");
            DecrementPercentage(request.AccessToken, request.Appliance, (float)request.DeltaPercentage.Value);
            return new Control.DecrementPercentageConfirmation { };
        }

        Alexa.ConnectedHome.System.HealthCheckResponse ProgressMessage(Alexa.ConnectedHome.System.HealthCheckRequest request)
        {
            LogInfo("Action: HealthCheck");
            string description;
            bool isHealthy = HealthCheck(long.Parse(request.InitiationTimestamp), out description);
            return new System.HealthCheckResponse(isHealthy, description);
        }
    }

    public abstract class SmartHomeHandler : AbstractSmartHomeHandler
    {
        protected override ApplianceDetails[] DiscoverAppliances(string accessToken)
        {
            throw new NotImplementedException();
        }

        //On/Off Messages
        protected override void TurnOn(string accessToken, Appliance appliance)
        {
            throw new NotImplementedException();
        }

        protected override void TurnOff(string accessToken, Appliance appliance)
        {
            throw new NotImplementedException();
        }

        //Tunable Lighting Control Messages

        protected override LightColor SetColor(string accessToken, Appliance appliance, LightColor color)
        {
            throw new NotImplementedException();
        }

        protected override int SetColorTemperature(string accessToken, Appliance appliance, int colorTemperature)
        {
            throw new NotImplementedException();
        }


        protected override int IncrementColorTemperature(string accessToken, Appliance appliance)
        {
            throw new NotImplementedException();
        }

        protected override int DecrementColorTemperature(string accessToken, Appliance appliance)
        {
            throw new NotImplementedException();
        }

        //Door Lock Control and Query Messages 

        protected override ApplianceLockState GetLockState(string accessToken, Appliance appliance, out DateTime applianceResponseTimestamp)
        {
            throw new NotImplementedException();
        }

        protected override ApplianceLockState SetLockState(string accessToken, Appliance appliance, ApplianceLockState lockState)
        {
            throw new NotImplementedException();
        }

        //Temperature Control and Query Messages
        protected override float GetTemperatureReading(string accessToken, Appliance appliance, out DateTime applianceResponseTimestamp)
        {
            throw new NotImplementedException();
        }

        protected override void GetTargetTemperature(string accessToken, Appliance appliance, out float targetTemperature, out TemperatureModeData temperatureMode, out DateTime applianceResponseTimestamp)
        {
            throw new NotImplementedException();
        }

        protected override void SetTargetTemperature(string accessToken, Appliance appliance, float targetTemperature, out TemperatureState currentState, out TemperatureState previousState)
        {
            throw new NotImplementedException();
        }

        protected override void IncrementTargetTemperature(string accessToken, Appliance appliance, float deltaTemperature, out TemperatureState currentState, out TemperatureState previousState)
        {
            throw new NotImplementedException();
        }

        protected override void DecrementTargetTemperature(string accessToken, Appliance appliance, float deltaTemperature, out TemperatureState currentState, out TemperatureState previousState)
        {
            throw new NotImplementedException();
        }

        //Percentage Messages

        protected override void SetPercentage(string accessToken, Appliance appliance, float percentage)
        {
            throw new NotImplementedException();
        }

        protected override void IncrementPercentage(string accessToken, Appliance appliance, float deltaPercentage)
        {
            throw new NotImplementedException();
        }

        protected override void DecrementPercentage(string accessToken, Appliance appliance, float deltaPercentage)
        {
            throw new NotImplementedException();
        }

        //Health Check Messages
        protected override bool HealthCheck(long initiationTimestamp, out string description)
        {
            throw new NotImplementedException();
        }
    }
}