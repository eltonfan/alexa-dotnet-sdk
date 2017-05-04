using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Elton.ConnectedHome
{
    public class MessageFactory
    {
        public const string PAYLOAD_VERSION = "2";

        readonly Dictionary<string, Type> dicTypes = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        public MessageFactory()
        {
        }

        public Type GetPayloadType(string fullName, string payloadVersion)
        {
            string key = null;
            if (string.IsNullOrWhiteSpace(payloadVersion))
                key = fullName;
            else
                key = fullName + "." + payloadVersion;

            dicTypes.TryGetValue(key, out Type type);
            return type;
        }

        public void AddPayloadType(Type payloadType, string payloadVersion = null)
        {
            string fullName = payloadType.FullName;

            string key = null;
            if (string.IsNullOrWhiteSpace(payloadVersion))
                key = fullName;
            else
                key = fullName + "." + payloadVersion;

            dicTypes.Add(key, payloadType);
        }

        public Message ParseMessage(string jsonString)
        {
            JObject obj = JObject.Parse(jsonString);

            return ParseMessage(obj);
        }
        public Message ParseMessage(JObject obj)
        {
            MessageHeader header = obj["header"].ToObject<MessageHeader>();
            Type payloadType = GetPayloadType(header.FullName, header.PayloadVersion);
            if (payloadType == null)
                return null;
            MessagePayload payload = obj["payload"].ToObject(payloadType) as MessagePayload;

            Message message = new Message
            {
                Header = header,
                Payload = payload,
            };

            return message;
        }

        public Message CreateMessage(MessagePayload payload)
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

            return message;
        }
        public string FormatMessage(MessagePayload payload)
        {
            Message message = CreateMessage(payload);
            return JsonConvert.SerializeObject(message);
        }

        public string FormatMessage(Message message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public ICollection<Type> SupportedMessages
        {
            get { return dicTypes.Values; }
        }
    }
}
