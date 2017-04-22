using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.ConnectedHome.Control
{
    /// <summary>
    /// Indicates a generic runtime error within the skill adapter. When possible, a more specific error should be returned.
    /// </summary>
    public class DriverInternalError : MessagePayload
    {
    }
    /* {
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"DriverInternalError",
        "payloadVersion":"2",
        "messageId":"e1ee71ed-952d-45fa-b2f4-2907649f48dc"
      },
      "payload":{
      }
    }*/

    /// <summary>
    ///  Indicates that a skill adapter dependency is unavailable and the skill adapter cannot complete the request.
    /// </summary>
    public class DependentServiceUnavailableError : MessagePayload
    {
        public string dependentServiceName { get; set; }
    }
    /*{
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"DependentServiceUnavailableError",
        "payloadVersion":"2",
        "messageId":"e1929526-66fb-4f99-869a-13c58bee88ef"
      },
      "payload":{
        "dependentServiceName":"Customer Credential Database"
      }
    }*/


    /// <summary>
    /// Indicates the cloud-connectivity for the target device is not stable and reliable.
    /// </summary>
    public class TargetConnectivityUnstableError : MessagePayload
    {
    }
    /*{
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"TargetConnectivityUnstableError",
        "payloadVersion":"2",
        "messageId":"502f0076-355c-4a5e-bb15-3ab7d78b8278"
      },
      "payload":{
      }
    }*/

    /// <summary>
    /// Indicates that cloud-connectivity for a home automation hub or bridge that connects the target device is unstable and unreliable.
    /// </summary>
    public class TargetBridgeConnectivityUnstableError : MessagePayload
    {
    }
    /*{
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"TargetBridgeConnectivityUnstableError",
        "payloadVersion":"2",
        "messageId":"502f0076-355c-4a5e-bb15-3ab7d78b8278"
      },
      "payload":{
      }
    }*/


    /// <summary>
    /// Indicates that the target device has outdated firmware.
    /// </summary>
    public class TargetFirmwareOutdatedError : MessagePayload
    {
        /// <summary>
        /// Alphanumeric value indicating minimum allowed firmware version. Maximum of 256 characters.
        /// </summary>
        public string minimumFirmwareVersion { get; set; }
        /// <summary>
        /// Alphanumeric value indicating current firmware version. Maximum of 256 characters.
        /// </summary>
        public string currentFirmwareVersion { get; set; }
    }
    /*{
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"TargetFirmwareOutdatedError",
        "payloadVersion":"2",
        "messageId":"917314cd-ca00-49ca-b75e-d6f65ac43503"
      },
      "payload":{
        "minimumFirmwareVersion":"17",
        "currentFirmwareVersion":"6"
      }
    }*/


    /// <summary>
    /// 
    /// </summary>
    public class TargetBridgeFirmwareOutdatedError : MessagePayload
    {
        /// <summary>
        /// Alphanumeric value indicating minimum allowed firmware version. Maximum of 256 characters.
        /// </summary>
        public string minimumFirmwareVersion { get; set; }
        /// <summary>
        /// Alphanumeric value indicating current firmware version. Maximum of 256 characters.
        /// </summary>
        public string currentFirmwareVersion { get; set; }
    }
    /*{
  "header":{
    "namespace":"Alexa.ConnectedHome.Control",
    "name":"TargetBridgeFirmwareOutdatedError",
    "payloadVersion":"2",
    "messageId":"917314cd-ca00-49ca-b75e-d6f65ac43503"
  },
  "payload":{
    "minimumFirmwareVersion":"17",
    "currentFirmwareVersion":"6"
  }
}*/

    /// <summary>
    /// Indicates that the target device experienced a hardware malfunction.
    /// </summary>
    public class TargetHardwareMalfunctionError : MessagePayload
    {
    }
    /*  {
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"TargetHardwareMalfunctionError",
        "payloadVersion":"2",
        "messageId":"3840d1ad-05fc-413c-b2ad-2aa237090a29"
      },
      "payload":{}
    }*/

    /// <summary>
    /// Indicates that the home automation hub or bridge connecting the target device experienced a hardware malfunction.
    /// </summary>
    public class TargetBridgetHardwareMalfunctionError : MessagePayload
    {
    }
    /* {
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"TargetBridgeHardwareMalfunctionError",
        "payloadVersion":"2",
        "messageId":"3840d1ad-05fc-413c-b2ad-2aa237090a29"
      },
      "payload":{
      }
    }*/


    public class ErrorInfo
    {
        /// <summary>
        /// An error code in string format. Currently, the valid value for code is THERMOSTAT_IS_OFF, which indicates the requested operation was rejected because the thermostat is off and the manufacturer is unwilling to automatically turn it on for safety reasons.
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// A custom description of the error from the device manufacturer.
        /// </summary>
        public string description { get; set; }
    }
    /*
        "errorInfo":{
          "code":"ThermostatIsOff",
          "description":"The requested operation is unsafe because it requires changing the mode."
        }
    */

    /// <summary>
    /// 
    /// </summary>
    public class UnwillingToSetValueError : MessagePayload
    {
        public ErrorInfo errorInfo { get; set; }
    }
    /* {
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"UnwillingToSetValueError",
        "payloadVersion":"2",
        "messageId":"917314cd-ca00-49ca-b75e-d6f65ac43503"
      },
      "payload":{
        "errorInfo":{
          "code":"ThermostatIsOff",
          "description":"The requested operation is unsafe because it requires changing the mode."
        }
      }
    }*/

    /// <summary>
    /// Indicates that the maximum number of requests that a device accepts has been exceeded. This message provides information about the maximum number of requests for a device and the time unit for those requests. For example, if a device accepts four requests per hour, the message should specify 4 and HOUR as rateLimit and timeUnit, respectively.
    /// </summary>
    public class RateLimitExceededError : MessagePayload
    {
        /// <summary>
        /// An integer that represents the maximum number of requests a device will accept in the specifed time unit.
        /// </summary>
        public string rateLimit { get; set; }
        /// <summary>
        /// An all-caps string that indicates the time unit for rateLimit such as MINUTE, HOUR or DAY.
        /// </summary>
        public string timeUnit { get; set; }
    }
    /*
     *  {
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"RateLimitExceededError",
        "payloadVersion":"2",
        "messageId":"917314cd-ca00-49ca-b75e-d6f65ac43503"
      },
      "payload":{
        "rateLimit":"10",
        "timeUnit":"HOUR"
      }
    }*/

    /// <summary>
    /// Indicates that the target device is in a mode in which it cannot be controlled with the Smart Home Skill API, and provides information about the current mode of the device.
    /// </summary>
    public class NotSupportedInCurrentModeError : MessagePayload
    {
        /// <summary>
        /// A string that represents the current mode of the device. Valid values are AUTO, COOL, HEAT, AWAY, and OTHER.
        /// </summary>
        public string currentDeviceMode { get; set; }
    }
    /*
     *  {
      "header":{
        "namespace":"Alexa.ConnectedHome.Control",
        "name":"NotSupportedInCurrentModeError",
        "payloadVersion":"2",
        "messageId":"917314cd-ca00-49ca-b75e-d6f65ac43503"
      },
      "payload":{
        "currentDeviceMode":"AWAY"
      }
    }*/
}