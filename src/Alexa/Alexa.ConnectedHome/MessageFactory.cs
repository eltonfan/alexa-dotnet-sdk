using Elton.ConnectedHome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome
{
    public class MessageFactory : Elton.ConnectedHome.AbstractMessageFactory
    {
        public const string PAYLOAD_VERSION = "2";

        static MessageFactory instance;
        public static MessageFactory Default
        {
            get
            {
                if (instance == null)
                    instance = new MessageFactory();

                return instance;
            }
        }

        public void AddPayloadType(Type payloadType)
        {
            base.AddPayloadType(payloadType, PAYLOAD_VERSION);
        }

        private MessageFactory()
        {
            //Discovery Messages
            AddPayloadType(typeof(Discovery.DiscoverAppliancesRequest));
            AddPayloadType(typeof(Discovery.DiscoverAppliancesResponse));

            //On/Off Messages
            AddPayloadType(typeof(Control.TurnOnRequest));
            AddPayloadType(typeof(Control.TurnOnConfirmation));
            AddPayloadType(typeof(Control.TurnOffRequest));
            AddPayloadType(typeof(Control.TurnOffConfirmation));

            //Tunable Lighting Control Messages
            AddPayloadType(typeof(Control.SetColorRequest));
            AddPayloadType(typeof(Control.SetColorConfirmation));
            AddPayloadType(typeof(Control.SetColorTemperatureRequest));
            AddPayloadType(typeof(Control.SetColorTemperatureConfirmation));
            AddPayloadType(typeof(Control.IncrementColorTemperatureRequest));
            AddPayloadType(typeof(Control.IncrementColorTemperatureConfirmation));
            AddPayloadType(typeof(Control.DecrementColorTemperatureRequest));
            AddPayloadType(typeof(Control.DecrementColorTemperatureConfirmation));

            //Door Lock Control and Query Messages 
            AddPayloadType(typeof(Query.GetLockStateRequest));
            AddPayloadType(typeof(Query.GetLockStateResponse));
            AddPayloadType(typeof(Control.SetLockStateRequest));
            AddPayloadType(typeof(Control.SetLockStateConfirmation));

            //Temperature Control and Query Messages
            AddPayloadType(typeof(Query.GetTemperatureReadingRequest));
            AddPayloadType(typeof(Query.GetTemperatureReadingResponse));
            AddPayloadType(typeof(Query.GetTargetTemperatureRequest));
            AddPayloadType(typeof(Query.GetTargetTemperatureResponse));
            AddPayloadType(typeof(Control.SetTargetTemperatureRequest));
            AddPayloadType(typeof(Control.SetTargetTemperatureConfirmation));
            AddPayloadType(typeof(Control.IncrementTargetTemperatureRequest));
            AddPayloadType(typeof(Control.IncrementTargetTemperatureConfirmation));
            AddPayloadType(typeof(Control.DecrementTargetTemperatureRequest));
            AddPayloadType(typeof(Control.DecrementTargetTemperatureConfirmation));

            //Percentage Messages
            AddPayloadType(typeof(Control.SetPercentageRequest));
            AddPayloadType(typeof(Control.SetPercentageConfirmation));
            AddPayloadType(typeof(Control.IncrementPercentageRequest));
            AddPayloadType(typeof(Control.IncrementPercentageConfirmation));
            AddPayloadType(typeof(Control.DecrementPercentageRequest));
            AddPayloadType(typeof(Control.DecrementPercentageConfirmation));

            //Health Check Messages
            AddPayloadType(typeof(Alexa.ConnectedHome.System.HealthCheckRequest));
            AddPayloadType(typeof(Alexa.ConnectedHome.System.HealthCheckResponse));

            //Error Messages - User Faults
            AddPayloadType(typeof(Control.ValueOutOfRangeError));
            AddPayloadType(typeof(Control.TargetOfflineError));
            AddPayloadType(typeof(Control.BridgeOfflineError));
            AddPayloadType(typeof(Control.NoSuchTargetError));
                
            //Error Messages - Skill Adapter Faults
            AddPayloadType(typeof(Control.DriverInternalError));
            AddPayloadType(typeof(Control.DependentServiceUnavailableError));
            AddPayloadType(typeof(Control.TargetConnectivityUnstableError));
            AddPayloadType(typeof(Control.TargetBridgeConnectivityUnstableError));
            AddPayloadType(typeof(Control.TargetFirmwareOutdatedError));
            AddPayloadType(typeof(Control.TargetBridgeFirmwareOutdatedError));
            AddPayloadType(typeof(Control.TargetHardwareMalfunctionError));
            AddPayloadType(typeof(Control.TargetBridgetHardwareMalfunctionError));
            AddPayloadType(typeof(Control.UnwillingToSetValueError));
            AddPayloadType(typeof(Control.RateLimitExceededError));
            AddPayloadType(typeof(Control.NotSupportedInCurrentModeError));

            //Error Messages - Other Faults
            AddPayloadType(typeof(Control.ExpiredAccessTokenError));
            AddPayloadType(typeof(Control.InvalidAccessTokenError));
            AddPayloadType(typeof(Control.UnsupportedTargetError));
            AddPayloadType(typeof(Control.UnsupportedOperationError));
            AddPayloadType(typeof(Control.UnsupportedTargetSettingError));
            AddPayloadType(typeof(Control.UnexpectedInformationReceivedError));
        }

        public static Message Parse(string jsonString)
        {
            return Default.ParseMessage(jsonString);
        }

        public static Message Parse(Newtonsoft.Json.Linq.JObject obj)
        {
            return Default.ParseMessage(obj);
        }

        public static Message Create(MessagePayload payload)
        {
            return Default.CreateMessage(payload);
        }

        public static string Format(MessagePayload payload)
        {
            return Default.FormatMessage(payload);
        }

        public static string Format(Message message)
        {
            return Default.FormatMessage(message);
        }
    }
}
