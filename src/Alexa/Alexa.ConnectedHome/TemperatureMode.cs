using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.ConnectedHome
{
    /// <summary>
    /// A string indicating the temperature mode set by the device.
    /// </summary>
    public enum TemperatureMode
    {
        /// <summary>
        /// Indicates automatic heat/cool selection
        /// </summary>
        AUTO,
        /// <summary>
        /// Indicates Cooling mode
        /// </summary>
        COOL,
        /// <summary>
        /// Indicates heating mode
        /// </summary>
        HEAT,
        /// <summary>
        /// Indicates economical mode
        /// </summary>
        ECO,
        /// <summary>
        /// Indicates heating/cooling is turned off, although device may still have power
        /// </summary>
        OFF,
        /// <summary>
        /// Indicates a custom mode that is specified by friendlyName
        /// </summary>
        CUSTOM,
    }
}
