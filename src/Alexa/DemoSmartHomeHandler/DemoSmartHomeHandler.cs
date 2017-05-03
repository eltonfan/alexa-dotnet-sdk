using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.ConnectedHome.Samples
{
    public class DemoSmartHomeHandler : SmartHomeHandler
    {
        static DemoSmartHomeHandler instance = null;

        public static Message Handle(JObject input, ILambdaContext context)
        {
            if (instance == null)
                instance = new DemoSmartHomeHandler();
            instance.SetContext(context);
            return instance.ProcessRequest(input);
        }

        ILambdaContext context = null;
        ILambdaLogger log = null;
        private DemoSmartHomeHandler() { }

        private void SetContext(ILambdaContext context)
        {
            this.context = context;
            this.log = (context == null) ? null : context.Logger;
        }

        protected override void Log(LogLevel level, string format, params object[] arguments)
        {
            if (log == null)
                return;
            log.LogLine(level.ToString().ToUpper() + ": " + string.Format(format, arguments));
        }

        protected override ApplianceDetails[] DiscoverAppliances(string accessToken)
        {
            throw new NotImplementedException();
        }

        protected override void TurnOn(string accessToken, Appliance appliance)
        {
            throw new NotImplementedException();
        }

        protected override void TurnOff(string accessToken, Appliance appliance)
        {
            throw new NotImplementedException();
        }
    }
}
