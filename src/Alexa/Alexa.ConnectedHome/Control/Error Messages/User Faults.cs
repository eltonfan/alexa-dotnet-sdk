using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    public class ValueOutOfRangeError : MessagePayload
    {
        /// <summary>
        /// A 64-bit  double indicating the lowest value allowed for the target device setting.
        /// </summary>
        public double minimumValue { get; set; }
        /// <summary>
        /// A 64-bit  double indicating highest value allowed for the target device setting.
        /// </summary>
        public double maximumValue { get; set; }
    }
    /*
      {
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":" ValueOutOfRangeError",
        "payloadVersion":"2",
        "messageId":"697fe957-c842-4545-a159-8a8c75fbe5bd"
      },
      "payload":{
        "minimumValue":15.0,
        "maximumValue":30.0
      }
    }
*/



    public class TargetOfflineError : MessagePayload
    {
    }
    /*
     *  {
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"TargetOfflineError",
        "payloadVersion":"2",
        "messageId":"15a248f6-8ab5-433d-a3ac-73c358e0bebd"
      },
      "payload":{
      }
    }*/


    public class BridgeOfflineError : MessagePayload
    {
    }
    /*
     * {
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"BridgeOfflineError",
        "payloadVersion":"2",
        "messageId":"49f72397-858f-41cb-a7d3-b8cfa4c5fd0f"
      },
      "payload":{
      }
    }*/


    public class NoSuchTargetError : MessagePayload
    {
    }
    /* {
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"NoSuchTargetError",
        "payloadVersion":"2",
        "messageId":"bc652339-1b09-423d-b679-1bd19ae59245"
      },
      "payload":{
      }
    }
*/
}
 