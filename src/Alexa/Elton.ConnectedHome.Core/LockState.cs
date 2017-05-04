using System.Runtime.Serialization;

namespace Elton.ConnectedHome
{
    public enum LockState
    {
        [EnumMember(Value = "LOCKED")]
        Locked,
        [EnumMember(Value = "UNLOCKED")]
        Unlocked,
    }
}
