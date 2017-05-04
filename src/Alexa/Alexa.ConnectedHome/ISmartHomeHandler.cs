using Elton.ConnectedHome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome
{
    public class SmartHomeContext
    {
        public string RequestJsonString { get; private set; }
        public Message Request { get; set; }
        public Message Response { get; set; }

        public SmartHomeContext(string request)
        {
            this.RequestJsonString = request;
            this.Request = null;
        }

        public SmartHomeContext(Message request)
        {
            this.RequestJsonString = null;
            this.Request = request;
        }
    }

    public interface ISmartHomeHandler
    {
        void ProcessRequest(SmartHomeContext context);
    }
}
