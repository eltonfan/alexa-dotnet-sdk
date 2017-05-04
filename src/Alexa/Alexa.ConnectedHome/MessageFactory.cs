using Elton.ConnectedHome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome
{
    public class MessageFactory : Elton.ConnectedHome.MessageFactory
    {
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

        private MessageFactory()
        {
            //Discovery Messages
            AddPayloadType(typeof(Discovery.DiscoverAppliancesRequest), "2");
            AddPayloadType(typeof(Discovery.DiscoverAppliancesResponse), "2");

            //On/Off Messages
            AddPayloadType(typeof(Control.TurnOnRequest), "2");
            AddPayloadType(typeof(Control.TurnOnConfirmation), "2");
            AddPayloadType(typeof(Control.TurnOffRequest), "2");
            AddPayloadType(typeof(Control.TurnOffConfirmation), "2");

            //Tunable Lighting Control Messages
            AddPayloadType(typeof(Control.SetColorRequest), "2");
            AddPayloadType(typeof(Control.SetColorConfirmation), "2");
            AddPayloadType(typeof(Control.SetColorTemperatureRequest), "2");
            AddPayloadType(typeof(Control.SetColorTemperatureConfirmation), "2");
            AddPayloadType(typeof(Control.IncrementColorTemperatureRequest), "2");
            AddPayloadType(typeof(Control.IncrementColorTemperatureConfirmation), "2");
            AddPayloadType(typeof(Control.DecrementColorTemperatureRequest), "2");
            AddPayloadType(typeof(Control.DecrementColorTemperatureConfirmation), "2");

            //Door Lock Control and Query Messages 
            AddPayloadType(typeof(Query.GetLockStateRequest), "2");
            AddPayloadType(typeof(Query.GetLockStateResponse), "2");
            AddPayloadType(typeof(Control.SetLockStateRequest), "2");
            AddPayloadType(typeof(Control.SetLockStateConfirmation), "2");

            //Temperature Control and Query Messages
            AddPayloadType(typeof(Query.GetTemperatureReadingRequest), "2");
            AddPayloadType(typeof(Query.GetTemperatureReadingResponse), "2");
            AddPayloadType(typeof(Query.GetTargetTemperatureRequest), "2");
            AddPayloadType(typeof(Query.GetTargetTemperatureResponse), "2");
            AddPayloadType(typeof(Control.SetTargetTemperatureRequest), "2");
            AddPayloadType(typeof(Control.SetTargetTemperatureConfirmation), "2");
            AddPayloadType(typeof(Control.IncrementTargetTemperatureRequest), "2");
            AddPayloadType(typeof(Control.IncrementTargetTemperatureConfirmation), "2");
            AddPayloadType(typeof(Control.DecrementTargetTemperatureRequest), "2");
            AddPayloadType(typeof(Control.DecrementTargetTemperatureConfirmation), "2");

            //Percentage Messages
            AddPayloadType(typeof(Control.SetPercentageRequest), "2");
            AddPayloadType(typeof(Control.SetPercentageConfirmation), "2");
            AddPayloadType(typeof(Control.IncrementPercentageRequest), "2");
            AddPayloadType(typeof(Control.IncrementPercentageConfirmation), "2");
            AddPayloadType(typeof(Control.DecrementPercentageRequest), "2");
            AddPayloadType(typeof(Control.DecrementPercentageConfirmation), "2");

            //Health Check Messages
            AddPayloadType(typeof(Alexa.ConnectedHome.System.HealthCheckRequest), "2");
            AddPayloadType(typeof(Alexa.ConnectedHome.System.HealthCheckResponse), "2");

            //Error Messages - User Faults
            AddPayloadType(typeof(Control.ValueOutOfRangeError), "2");
            AddPayloadType(typeof(Control.TargetOfflineError), "2");
            AddPayloadType(typeof(Control.BridgeOfflineError), "2");
            AddPayloadType(typeof(Control.NoSuchTargetError), "2");
                
            //Error Messages - Skill Adapter Faults
            AddPayloadType(typeof(Control.DriverInternalError), "2");
            AddPayloadType(typeof(Control.DependentServiceUnavailableError), "2");
            AddPayloadType(typeof(Control.TargetConnectivityUnstableError), "2");
            AddPayloadType(typeof(Control.TargetBridgeConnectivityUnstableError), "2");
            AddPayloadType(typeof(Control.TargetFirmwareOutdatedError), "2");
            AddPayloadType(typeof(Control.TargetBridgeFirmwareOutdatedError), "2");
            AddPayloadType(typeof(Control.TargetHardwareMalfunctionError), "2");
            AddPayloadType(typeof(Control.TargetBridgetHardwareMalfunctionError), "2");
            AddPayloadType(typeof(Control.UnwillingToSetValueError), "2");
            AddPayloadType(typeof(Control.RateLimitExceededError), "2");
            AddPayloadType(typeof(Control.NotSupportedInCurrentModeError), "2");

            //Error Messages - Other Faults
            AddPayloadType(typeof(Control.ExpiredAccessTokenError), "2");
            AddPayloadType(typeof(Control.InvalidAccessTokenError), "2");
            AddPayloadType(typeof(Control.UnsupportedTargetError), "2");
            AddPayloadType(typeof(Control.UnsupportedOperationError), "2");
            AddPayloadType(typeof(Control.UnsupportedTargetSettingError), "2");
            AddPayloadType(typeof(Control.UnexpectedInformationReceivedError), "2");
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
