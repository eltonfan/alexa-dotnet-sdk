using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alexa.ConnectedHome;

namespace Elton.ConnectedHome.Messaging
{
    public class HeartbeatReport : MessagePayload
    {
        public string description { get; set; }
    }
}
