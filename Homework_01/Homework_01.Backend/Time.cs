namespace Homework_01.Backend
{
    public class Time
    {
        private int _hour;
        private int _millisecond;
        private int _minute;
        private int _second;

        public Time() {
            _hour = 0;
            _millisecond = 0;
            _minute = 0;
            _second = 0;
        }
        public Time(int hours)
        {
            Hour = hours;
            _millisecond = 0;
            _minute = 0;
            _second = 0;
        }
        public Time(int hours, int minutes)
        {
            Hour = hours;
            _millisecond = 0;
            Minute = minutes;
            _second = 0;
        }

        public Time(int hours, int minutes, int seconds)
        {
            Hour = hours;
            _millisecond = 0;
            Minute = minutes;
            Second = seconds;
        }
        public Time(int hours, int minutes, int seconds,int milliseconds)
        {
            Hour = hours;
            Millisecond = milliseconds;
            Minute = minutes;
            Second = seconds;
        }
        public int Hour
        {
            get => _hour;
            set => _hour = ValidHour(value);
        }
        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = value;
        }
        public int Minute
        {
            get => _minute;
            set => _minute = value;
        }
        public int Second
        {
            get => _second;
            set => _second = value;
        }
        private int ValidHour( int hour)
        {
            if(hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(hour), $"The hour : {hour}, is not valid. ");
            }
            return hour;

        }
        private int ValidMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minute), $"The Minute : {minute}, is not valid. ");
            }
            return minute;

        }
        /*private int ValidSecondo(int second)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minute), $"The Minute : {minute}, is not valid. ");
            }
            return minute;

        }*/

    }
}
