using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome
{
    public class MessageFactory
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


        public const string PAYLOAD_VERSION = "2";

        readonly Dictionary<string, Type> dicTypes = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        private MessageFactory()
        {
            Type[] array = new Type[] {
                //Discovery Messages
                typeof(Discovery.DiscoverAppliancesRequest),
                typeof(Discovery.DiscoverAppliancesResponse),

                //On/Off Messages
                typeof(Control.TurnOnRequest),
                typeof(Control.TurnOnConfirmation),
                typeof(Control.TurnOffRequest),
                typeof(Control.TurnOffConfirmation),

                //Door Lock Control and Query Messages 
                typeof(Query.GetLockStateRequest),
                typeof(Query.GetLockStateResponse),
                typeof(Control.SetLockStateRequest),
                typeof(Control.SetLockStateConfirmation),

                //Temperature Control and Query Messages
                typeof(Query.GetTemperatureReadingRequest),
                typeof(Query.GetTemperatureReadingResponse),
                typeof(Query.GetTargetTemperatureRequest),
                typeof(Query.GetTargetTemperatureResponse),
                typeof(Control.SetTargetTemperatureRequest),
                typeof(Control.SetTargetTemperatureConfirmation),
                typeof(Control.IncrementTargetTemperatureRequest),
                typeof(Control.IncrementTargetTemperatureConfirmation),
                typeof(Control.DecrementTargetTemperatureRequest),
                typeof(Control.DecrementTargetTemperatureConfirmation),

                //Percentage Messages
                typeof(Control.SetPercentageRequest),
                typeof(Control.SetPercentageConfirmation),
                typeof(Control.IncrementPercentageRequest),
                typeof(Control.IncrementPercentageConfirmation),
                typeof(Control.DecrementPercentageRequest),
                typeof(Control.DecrementPercentageConfirmation),

                //Health Check Messages
                typeof(Alexa.ConnectedHome.System.HealthCheckRequest),
                typeof(Alexa.ConnectedHome.System.HealthCheckResponse),

                //Error Messages - User Faults
                typeof(Control.ValueOutOfRangeError),
                typeof(Control.TargetOfflineError),
                typeof(Control.BridgeOfflineError),
                typeof(Control.NoSuchTargetError),
                
                //Error Messages - Skill Adapter Faults
                typeof(Control.DriverInternalError),
                typeof(Control.DependentServiceUnavailableError),
                typeof(Control.TargetConnectivityUnstableError),
                typeof(Control.TargetBridgeConnectivityUnstableError),
                typeof(Control.TargetFirmwareOutdatedError),
                typeof(Control.TargetBridgeFirmwareOutdatedError),
                typeof(Control.TargetHardwareMalfunctionError),
                typeof(Control.TargetBridgetHardwareMalfunctionError),
                typeof(Control.UnwillingToSetValueError),
                typeof(Control.RateLimitExceededError),
                typeof(Control.NotSupportedInCurrentModeError),

                //Error Messages - Other Faults
                typeof(Control.ExpiredAccessTokenError),
                typeof(Control.InvalidAccessTokenError),
                typeof(Control.UnsupportedTargetError),
                typeof(Control.UnsupportedOperationError),
                typeof(Control.UnsupportedTargetSettingError),
                typeof(Control.UnexpectedInformationReceivedError),
            };

            foreach (var item in array)
            {
                dicTypes.Add(item.FullName, item);
            }
        }

        public IEnumerable<Type> SupportedMessages
        {
            get { return dicTypes.Values; }
        }

        protected Message ParseMessage(string jsonString)
        {
            JObject obj = JObject.Parse(jsonString);
            MessageHeader header = obj["header"].ToObject<MessageHeader>();
            string fullName = header.FullName;
            if (!dicTypes.ContainsKey(fullName))
                return null;

            Type messageType = dicTypes[fullName];
            MessagePayload payload = obj["payload"].ToObject(messageType) as MessagePayload;

            Message message = new Message
            {
                Header = header,
                Payload = payload,
            };

            return message;
        }

        protected string FormatMessage(MessagePayload payload)
        {
            Type type = payload.GetType();
            Message message = new Message
            {
                Header = new MessageHeader
                {
                    MessageId = Guid.NewGuid(),
                    Namespace = type.Namespace,
                    Name = type.Name,
                    PayloadVersion = PAYLOAD_VERSION,
                },
                Payload = payload,
            };

            return JsonConvert.SerializeObject(message);
        }

        public static Message Parse(string jsonString)
        {
            return Default.ParseMessage(jsonString);
        }

        public static string Format(MessagePayload payload)
        {
            return Default.FormatMessage(payload);
        }

        public static string Format(Message message)
        {
            return JsonConvert.SerializeObject(message);
        }
    }
}
