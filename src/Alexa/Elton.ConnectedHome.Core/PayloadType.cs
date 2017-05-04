using System;
using System.Collections.Generic;
using System.Text;

namespace Elton.ConnectedHome
{
    public class PayloadType
    {
        public string FullName { get; private set; }
        public Type Type { get; private set; }
        public string Version { get; private set; }

        public PayloadType(Type type, string version)
        {
            this.Type = type;
            this.Version = version;

            this.FullName = GetFullName(Type, Version);
        }

        public static string GetFullName(Type type, string version)
        {
            return GetFullName(type.FullName, version);
        }

        public static string GetFullName(string typeName, string version)
        {
            string fullName = null;
            if (string.IsNullOrWhiteSpace(version))
                fullName = typeName;
            else
                fullName = typeName + "." + version;

            return fullName;
        }
    }
}
