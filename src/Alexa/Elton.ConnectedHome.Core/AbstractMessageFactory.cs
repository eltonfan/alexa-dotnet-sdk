using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Elton.ConnectedHome
{
    public abstract class AbstractMessageFactory
    {
        readonly Dictionary<string, PayloadType> dicTypes = new Dictionary<string, PayloadType>(StringComparer.OrdinalIgnoreCase);
        public AbstractMessageFactory()
        {
        }

        public PayloadType GetPayloadType(string typeName, string payloadVersion)
        {
            string key = PayloadType.GetFullName(typeName, payloadVersion);
            dicTypes.TryGetValue(key, out PayloadType type);
            return type;
        }

        public void AddPayloadType(Type payloadType, string payloadVersion)
        {
            PayloadType item = new PayloadType(payloadType, payloadVersion);
            string fullName = item.FullName;
            if (dicTypes.ContainsKey(fullName))
                dicTypes[fullName] = item;
            else
                dicTypes.Add(fullName, item);
        }

        public Message ParseMessage(string jsonString)
        {
            JObject obj = JObject.Parse(jsonString);

            return ParseMessage(obj);
        }
        public Message ParseMessage(JObject obj)
        {
            MessageHeader header = obj["header"].ToObject<MessageHeader>();
            var payloadType = GetPayloadType(header.FullName, header.PayloadVersion);
            if (payloadType == null)
                return null;
            MessagePayload payload = obj["payload"].ToObject(payloadType.Type) as MessagePayload;

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

            PayloadType payloadType = null;
            foreach (var item in dicTypes.Values)
            {
                if(item.Type == type)
                {
                    payloadType = item;
                    break;
                }
            }
            if (payloadType == null)
                throw new NotSupportedException("Not supported payload type: " + type.FullName);

            Message message = new Message
            {
                Header = new MessageHeader
                {
                    MessageId = Guid.NewGuid(),
                    Namespace = type.Namespace,
                    Name = type.Name,
                    PayloadVersion = payloadType.Version,
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

        public ICollection<PayloadType> SupportedMessages
        {
            get { return dicTypes.Values; }
        }
    }
}
