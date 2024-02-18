using System;
using System.Threading;
namespace HAFB
{
    public delegate void CallbackFunction(string message);

    public class Controller
    {
        private readonly CallbackFunction _callbackFunction;

        public Controller(CallbackFunction callbackFunction)
        {
            _callbackFunction = callbackFunction;
        }

        /// <summary>
        // Sends the view a message every 5 seconds
        /// </summary>
        public void StartTimer()
        {
            Timer timer = new Timer(state =>
            {
                Time currentTime = GetCurrentTime();
                SetTime(currentTime);
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        public Time GetCurrentTime()
        {
            DateTime now = DateTime.Now;

            int hour = now.Hour > 12 ? now.Hour - 12 : now.Hour;
            string ampm = now.Hour >= 12 ? "PM" : "AM";

            return new Time { Hour = hour, Minute = now.Minute, AMPM = ampm };
        }

        /// <summary>
        /// This is the method I described for my technical interview solution
        /// </summary>
        /// <param name="t"></param>
        /// <returns>aThe message getting sent to the view</returns>
        public void SetTime(Time t)
        {
            string min = t.Minute < 10 ? "0" : "";
            min += t.Minute;
            string ampm = t.AMPM == "AM" ? "morning" : "afternoon";
            string message = $"It is {t.Hour}:{min} in the {ampm}.";
            _callbackFunction.Invoke(message);
        }
    }
}