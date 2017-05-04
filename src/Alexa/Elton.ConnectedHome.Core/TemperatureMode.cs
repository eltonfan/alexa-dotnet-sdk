using System.Runtime.Serialization;

namespace Elton.ConnectedHome
{
    /// <summary>
    /// A string indicating the temperature mode set by the device.
    /// </summary>
    public enum TemperatureMode
    {
        /// <summary>
        /// Indicates automatic heat/cool selection
        /// </summary>
        [EnumMember(Value = "AUTO")]
        Automatic,
        /// <summary>
        /// Indicates Cooling mode
        /// </summary>
        [EnumMember(Value = "COOL")]
        Cooling,
        /// <summary>
        /// Indicates heating mode
        /// </summary>
        [EnumMember(Value = "HEAT")]
        Heating,
        /// <summary>
        /// Indicates economical mode
        /// </summary>
        [EnumMember(Value = "ECO")]
        Economical,
        /// <summary>
        /// Indicates heating/cooling is turned off, although device may still have power
        /// </summary>
        [EnumMember(Value = "OFF")]
        Off,
        /// <summary>
        /// Indicates a custom mode that is specified by friendlyName
        /// </summary>
        [EnumMember(Value = "CUSTOM")]
        Custom,
    }
}
