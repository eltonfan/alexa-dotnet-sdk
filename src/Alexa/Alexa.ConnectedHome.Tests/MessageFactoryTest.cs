using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Alexa.ConnectedHome.Tests
{
    [TestClass]
    public class MessageFactoryTest
    {
        private TestContext context = null;
        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }

        public string JsonExampleDir
        {
            get
            {
                return Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    @"examples\json\");
            }
        }

        string ReadExampleJsonString(Type payloadType)
        {
            if (!payloadType.Namespace.StartsWith("Alexa.ConnectedHome."))
                throw new NotSupportedException(string.Format("The message type '{0}' is not supported.", payloadType.FullName));

            string fileName = Path.Combine(
                JsonExampleDir,
                payloadType.Namespace.Substring("Alexa.ConnectedHome.".Length).Replace('.', Path.AltDirectorySeparatorChar),
                payloadType.Name + ".json");

            if (!File.Exists(fileName))
                throw new FileNotFoundException("The json file is not found." + fileName, fileName);

            return File.ReadAllText(fileName, Encoding.UTF8);
        }

        void TestMessageParseAndFormat(Type payloadType)
        {
            string jsonString = ReadExampleJsonString(payloadType);
            Message message = MessageFactory.Parse(jsonString);
            Assert.IsNotNull(message, "Failed to parse message '{0}'.", payloadType.FullName);
            Assert.AreEqual(message.Payload.GetType(), payloadType);

            string actual = MessageFactory.Format(message);
            Assert.IsTrue(JToken.DeepEquals(JObject.Parse(jsonString), JObject.Parse(actual)), 
                "Message '{0}' json Data is incorrect.", payloadType.FullName);
        }

        void TestMessages(params Type[] payloadTypes)
        {
            foreach (Type type in payloadTypes)
            {
                TestMessageParseAndFormat(type);
            }
        }

        [TestMethod]
        public void TestDiscoveryMessages()
        {
            //Discovery Messages
            TestMessages(
                typeof(Discovery.DiscoverAppliancesRequest),
                typeof(Discovery.DiscoverAppliancesResponse));
        }

        [TestMethod]
        public void TestSystemMessages()
        {
            //Health Check Messages
            TestMessages(
                typeof(Alexa.ConnectedHome.System.HealthCheckRequest),
                typeof(Alexa.ConnectedHome.System.HealthCheckResponse));
        }

        [TestMethod]
        public void TestOnOffMessages()
        {
            //On/Off Messages
            TestMessages(
                typeof(Control.TurnOnRequest),
                typeof(Control.TurnOnConfirmation),
                typeof(Control.TurnOffRequest),
                typeof(Control.TurnOffConfirmation));
        }

        [TestMethod]
        public void TestPercentageMessages()
        {
            //Percentage Messages
            TestMessages(typeof(Control.SetPercentageRequest));
            TestMessages(typeof(Control.SetPercentageConfirmation));
            TestMessages(typeof(Control.IncrementPercentageRequest));
            TestMessages(typeof(Control.IncrementPercentageConfirmation));
            TestMessages(typeof(Control.DecrementPercentageRequest));
            TestMessages(typeof(Control.DecrementPercentageConfirmation));
        }

        //[TestMethod]
        public void TestAllMessage()
        {
            foreach (Type messageType in MessageFactory.Default.SupportedMessages)
                TestMessageParseAndFormat(messageType);
        }
    }
}
