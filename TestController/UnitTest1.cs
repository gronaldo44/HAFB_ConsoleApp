using HAFB;

namespace ControllerTests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// This is the test I described in the technical interview
        /// 
        /// Here we are testing that minutes less than 10 work,
        /// hours in both the afternoon and morning work,
        /// and military times work.
        /// </summary>
        [TestMethod]
        public void TestSetTime()
        {
            // Various edge cases for testing SetTime
            Time[] testTimes = { new Time { Hour = 1, Minute = 0, AMPM = "AM" },
                            new Time {Hour = 12, Minute = 10, AMPM = "PM" },
                            new Time {Hour = 11, Minute = 59, AMPM = "AM" },
                            new Time {Hour = 13, Minute = 9, AMPM = "PM" } };
            string[] expectedMsgs = {"It is 1:00 in the morning.",
                                    "It is 12:10 in the afternoon.",
                                    "It is 11:59 in the morning.",
                                    "It is 1:09 in the afternoon."};

            for (int i = 0; i < testTimes.Length; i++)
            {
                Controller controller = new Controller(SetMessageReceivedCallback);
                controller.SetTime(testTimes[i]);
                Assert.AreEqual(expectedMsgs[i], _messageReceived);
            }
        }

        private string? _messageReceived;
        [TestMethod]
        public void GetCurrentTime_Returns_CurrentTime()
        {
            Controller controller = new Controller(null);

            Time currentTime = controller.GetCurrentTime();

            Assert.IsNotNull(currentTime);
        }
        [TestMethod]
        public void SetTime_SendsCorrectMessageToCallback()
        {
            Controller controller = new Controller(SetMessageReceivedCallback);

            Time testTime = new Time { Hour = 10, Minute = 30, AMPM = "AM" };
            controller.SetTime(testTime);

            string expectedMessage = "It is 10:30 in the morning.";
            Assert.AreEqual(expectedMessage, _messageReceived);
        }
        private void SetMessageReceivedCallback(string message)
        {
            _messageReceived = message;
        }
    }
}