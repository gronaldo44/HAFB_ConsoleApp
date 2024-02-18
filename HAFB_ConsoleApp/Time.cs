namespace HAFB
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private string? _ampm;

        public int Hour
        {
            get { return _hour; }
            set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentOutOfRangeException("Hour must be between 1 and 24.");
                }
                if (value > 12) 
                {
                    _hour = value - 12;
                } else if (value == 0)
                {
                    _hour = 12;
                } else
                {
                    _hour = value;
                }
            }
        }

        public int Minute
        {
            get { return _minute; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException("Minute must be between 0 and 59.");
                }
                _minute = value;
            }
        }

        public string AMPM
        {
            get { return _ampm; }
            set
            {
                if (value != "AM" && value != "PM")
                {
                    throw new ArgumentException("AMPM must be either 'AM' or 'PM'.");
                }
                _ampm = value;
            }
        }
    }
}

