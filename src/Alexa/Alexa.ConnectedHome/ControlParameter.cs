using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome
{
    public class ControlParameter
    {
        [JsonProperty("value")]
        public object Value { get; set; }

        public ControlParameter()
        { }

        public ControlParameter(object value)
        {
            this.Value = value;
        }
    }

    public class ControlParameter<T>
    {
        [JsonProperty("value")]
        public T Value { get; set; }

        public ControlParameter()
        { }

        public ControlParameter(T value)
        {
            this.Value = value;
        }
    }
}
