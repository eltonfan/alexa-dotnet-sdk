using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome
{
    public abstract class SmartHomeHandler
    {
        ILambdaContext context = null;
        ILambdaLogger log = null;

        protected virtual void LogLine(string format, params object[] arguments)
        {
            if (log == null)
                return;

            log.LogLine(string.Format(format, arguments));
        }

        public Message Handle(string input)
        {
            this.context = null;
            this.log = null;

            return ProgressMessage(MessageFactory.Parse(input));
        }

        public Message Handle(JObject input, ILambdaContext context)
        {
            this.context = context;
            this.log = (context == null) ? null : context.Logger;

            return ProgressMessage(MessageFactory.Parse(input));
        }

        public Message ProgressMessage(Message request)
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
            catch(Exception ex)
            {
                response = new Control.NoSuchTargetError();
            }

            return MessageFactory.Create(response);
        }

        protected abstract Discovery.Appliance[] DiscoverAppliances(string accessToken);

        //On/Off Messages
        protected abstract void TurnOn(string accessToken, Appliance appliance);
        protected abstract void TurnOff(string accessToken, Appliance appliance);
        //Tunable Lighting Control Messages
        protected abstract LightColor SetColor(string accessToken, Appliance appliance, LightColor color);
        protected abstract float SetColorTemperature(string accessToken, Appliance appliance, float colorTemperature);
        protected abstract float IncrementColorTemperature(string accessToken, Appliance appliance);
        protected abstract float DecrementColorTemperature(string accessToken, Appliance appliance);
        //Door Lock Control and Query Messages 
        protected abstract string GetLockState(string accessToken, Appliance appliance, out DateTime applianceResponseTimestamp);
        protected abstract string SetLockState(string accessToken, Appliance appliance, string lockState);
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
            LogLine("Action: DiscoverAppliances");
            var result = DiscoverAppliances(request.AccessToken);
            return new Discovery.DiscoverAppliancesResponse
            {
                discoveredAppliances = result,
            };
        }

        Control.TurnOnConfirmation ProgressMessage(Control.TurnOnRequest request)
        {
            LogLine("Action: TurnOn");
            TurnOn(request.AccessToken, request.Appliance);
            return new Control.TurnOnConfirmation { };
        }

        Control.TurnOffConfirmation ProgressMessage(Control.TurnOffRequest request)
        {
            LogLine("Action: TurnOff");
            TurnOff(request.AccessToken, request.Appliance);
            return new Control.TurnOffConfirmation { };
        }

        Control.SetColorConfirmation ProgressMessage(Control.SetColorRequest request)
        {
            LogLine("Action: SetColor");
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
            LogLine("Action: SetColorTemperature");
            var achievedState = SetColorTemperature(request.AccessToken, request.Appliance, (float)request.ColorTemperature.Value);

            return new Control.SetColorTemperatureConfirmation
            {
                 AchievedState = new Control.ColorTemperatureAchievedState
                 {
                     ColorTemperature = new ControlParameter { Value = achievedState },
                 }
            };
        }
        Control.IncrementColorTemperatureConfirmation ProgressMessage(Control.IncrementColorTemperatureRequest request)
        {
            LogLine("Action: IncrementColorTemperature");
            var achievedState = IncrementColorTemperature(request.AccessToken, request.Appliance);
            return new Control.IncrementColorTemperatureConfirmation
            {
                 AchievedState = new Control.ColorTemperatureAchievedState
                 {
                      ColorTemperature = new ControlParameter {  Value = achievedState },
                 }
            };

        }
        Control.DecrementColorTemperatureConfirmation ProgressMessage(Control.DecrementColorTemperatureRequest request)
        {
            LogLine("Action: DecrementColorTemperature");
            var achievedState = DecrementColorTemperature(request.AccessToken, request.Appliance);
            return new Control.DecrementColorTemperatureConfirmation
            {
                AchievedState = new Control.ColorTemperatureAchievedState
                {
                    ColorTemperature = new ControlParameter(achievedState),
                }
            };
        }

        Query.GetLockStateResponse ProgressMessage(Query.GetLockStateRequest request)
        {
            LogLine("Action: GetLockState");
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
            LogLine("Action: SetLockState");
            var currentState = SetLockState(request.AccessToken, request.Appliance, request.LockState);
            return new Control.SetLockStateConfirmation
            {
                 LockState = currentState,
            };
        }

        Query.GetTemperatureReadingResponse ProgressMessage(Query.GetTemperatureReadingRequest request)
        {
            LogLine("Action: GetTemperatureReading");
            DateTime applianceResponseTimestamp;
            float temperature = GetTemperatureReading(request.AccessToken, request.Appliance, out applianceResponseTimestamp);

            return new Query.GetTemperatureReadingResponse
            {
                 TemperatureReading = new ControlParameter(temperature),
                  ApplianceResponseTimestamp = applianceResponseTimestamp,
            };

        }

        Query.GetTargetTemperatureResponse ProgressMessage(Query.GetTargetTemperatureRequest request)
        {
            LogLine("Action: GetTargetTemperature");
            float targetTemperature;
            TemperatureModeData temperatureMode;
            DateTime applianceResponseTimestamp;
            GetTargetTemperature(request.AccessToken, request.Appliance,
                out targetTemperature, out temperatureMode, out applianceResponseTimestamp);

            return new Query.GetTargetTemperatureResponse
            {
                TargetTemperature = new ControlParameter(targetTemperature),
                ApplianceResponseTimestamp = applianceResponseTimestamp,
                TemperatureMode = temperatureMode,
            };
        }

        Control.SetTargetTemperatureConfirmation ProgressMessage(Control.SetTargetTemperatureRequest request)
        {
            LogLine("Action: SetTargetTemperature");
            TemperatureState currentState, previousState;
            SetTargetTemperature(request.AccessToken, request.Appliance, (float)request.TargetTemperature.Value,
                out currentState, out previousState);

            return new Control.SetTargetTemperatureConfirmation
            {
                TargetTemperature = currentState.TargetTemperature,
                TemperatureMode = currentState.Mode,
                PreviousState =  previousState,
            };
        }

        Control.IncrementTargetTemperatureConfirmation ProgressMessage(Control.IncrementTargetTemperatureRequest request)
        {
            LogLine("Action: IncrementTargetTemperature");
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
            LogLine("Action: DecrementTargetTemperature");
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
            LogLine("Action: SetPercentage");
            SetPercentage(request.AccessToken, request.Appliance, (float)request.PercentageState.Value);
            return new Control.SetPercentageConfirmation { };
        }

        Control.IncrementPercentageConfirmation ProgressMessage(Control.IncrementPercentageRequest request)
        {
            LogLine("Action: IncrementPercentage");
            IncrementPercentage(request.AccessToken, request.Appliance, (float)request.DeltaPercentage.Value);
            return new Control.IncrementPercentageConfirmation { };
        }

        Control.DecrementPercentageConfirmation ProgressMessage(Control.DecrementPercentageRequest request)
        {
            LogLine("Action: DecrementPercentage");
            DecrementPercentage(request.AccessToken, request.Appliance, (float)request.DeltaPercentage.Value);
            return new Control.DecrementPercentageConfirmation { };
        }

        Alexa.ConnectedHome.System.HealthCheckResponse ProgressMessage(Alexa.ConnectedHome.System.HealthCheckRequest request)
        {
            LogLine("Action: HealthCheck");
            string description;
            bool isHealthy = HealthCheck(long.Parse(request.InitiationTimestamp), out description);
            return new System.HealthCheckResponse(isHealthy, description);
        }
    }
}