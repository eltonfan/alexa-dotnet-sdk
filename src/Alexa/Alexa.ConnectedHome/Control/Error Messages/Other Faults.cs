using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    /// <summary>
    /// Indicates that the access token used for authentication has expired and is no longer valid.
    /// </summary>
    public class ExpiredAccessTokenError : MessagePayload
    {
    }
    /*{
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"ExpiredAccessTokenError",
        "payloadVersion":"2",
        "messageId":"e1ee71ed-952d-45fa-b2f4-2907649f48dc"
      },
      "payload":{
      }
    }*/

    /// <summary>
    /// Indicates that the access token used for authentication is not valid for a reason other than it has expired.
    /// </summary>
    public class InvalidAccessTokenError : MessagePayload
    {
    }
    /*
     *  {
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"InvalidAccessTokenError",
        "payloadVersion":"2",
        "messageId":"e1ee71ed-952d-45fa-b2f4-2907649f48dc"
      },
      "payload":{
      }
    }*/

    /// <summary>
    /// Indicates that the target device is not supported by the skill adapter.
    /// </summary>
    public class UnsupportedTargetError : MessagePayload
    {
    }
    /*{
  "header":{
    "namespace":"Alexa.ConnectedHome.Control",
    "name":"UnsupportedTargetError",
    "payloadVersion":"2",
    "messageId":"e1ee71ed-952d-45fa-b2f4-2907649f48dc"
  },
  "payload":{
  }
}*/

    /// <summary>
    /// Indicates that the requested operation is not supported on the target device.
    /// </summary>
    public class UnsupportedOperationError : MessagePayload
    {
    }
    /*{
  "header":{
    "namespace":"Alexa.ConnectedHome.Control",
    "name":"UnsupportedOperationError",
    "payloadVersion":"2",
    "messageId":"e1ee71ed-952d-45fa-b2f4-2907649f48dc"
  },
  "payload":{
  }
}*/

    /// <summary>
    /// Indicates that the requested setting is not valid for the specified device and operation.
    /// </summary>
    public class UnsupportedTargetSettingError : MessagePayload
    {
    }
    /*{
  "header":{
    "namespace":"Alexa.ConnectedHome.Control",
    "name":"UnsupportedTargetSettingError",
    "payloadVersion":"2",
    "messageId":"e1ee71ed-952d-45fa-b2f4-2907649f48dc"
  },
  "payload":{
  }
}*/

    /// <summary>
    /// The request message or payload could not be handled by the skill adapter because it was malformed.
    /// </summary>
    public class UnexpectedInformationReceivedError : MessagePayload
    {
        /// <summary>
        /// The property or field in the request message that was malformed or unexpected, and could not be handled by the skill adapter.
        /// </summary>
        public string faultingParameter { get; set; }
    }
    /*{
  "header":{
    "namespace":"Alexa.ConnectedHome.Control",
    "name":"UnexpectedInformationReceivedError",
    "payloadVersion":"2",
    "messageId":"e1ee71ed-952d-45fa-b2f4-2907649f48dc"
  },
  "payload":{'
    "faultingParameter": "value"
  }
}*/
}