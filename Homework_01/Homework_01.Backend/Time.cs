using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_01.Backend
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        public Time()
        {
            _hour = 0;
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }
        public Time(int hours)
        {
            Hour = hours;
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }
        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
            _second = 0;
            _millisecond = 0;
        }

        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            _millisecond = 0;
        }
        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
        }
        public int Hour
        {
            get => _hour;
            set => _hour = ValidHour(value);
        }
        public int Minute
        {
            get => _minute;
            set => _minute = ValidMinute(value);
        }
        public int Second
        {
            get => _second;
            set => _second = ValidSecond(value);
        }
        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = ValidMillisecond(value);
        }
        private int ValidHour(int hour)
        {
            if (hour < 0 || hour > 23)
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
        private int ValidSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(second), $"The Second : {second}, is not valid. ");
            }
            return second;

        }
        private int ValidMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
            {
                throw new ArgumentOutOfRangeException(nameof(millisecond), $"The ValidMillisecond : {millisecond}, is not valid. ");
            }
            return millisecond;

        }
        public override string ToString()

        {
            int localhour;
            string tt = "AM";
            if (Hour == 12)
            {
                tt = "PM";
                localhour = Hour;
                return $"{localhour:00}:{Minute:00}:{Second:00}.{Millisecond:000} {tt}";
            }
            else if (Hour > 12)
            {
                tt = "PM";
                localhour = Hour - 12;
                return $"{localhour:00}:{Minute:00}:{Second:00}.{Millisecond:000} {tt}";
            }
            else if (Hour == 00)
            {
                tt = "AM";
                localhour = 12;
                return $"{localhour:00}:{Minute:00}:{Second:00}.{Millisecond:000} {tt}";
            }


            return $"{Hour:00}:{Minute:00}:{Second:00}.{Millisecond:000} {tt}";
        }

        public int ToMilliseconds()
        {
            var hours = Hour * 3600000;
            var minutes = Minute * 60000;
            var seconds = Second * 1000;
            var milliseconds = Millisecond;

            return hours + minutes + seconds + milliseconds;
        }

        public int ToSeconds()
        {
            return ToMilliseconds() / 1000;
        }
        public int ToMinutes()
        {
            return ToMilliseconds() / 60000;
        }
        public Time Add(Time t)
        {
            var totalMillisenconds = Millisecond + t.Millisecond;
            var extraSeconds = totalMillisenconds / 1000;
            var milliseconds = totalMillisenconds % 1000;

            var totalSeconds = Second + extraSeconds + t.Second;
            var extraMinutes = totalSeconds / 60;
            var seconds = totalSeconds % 60;

            var totalMinutes = Minute + extraMinutes + t.Minute;
            var extraHour = totalMinutes / 60;
            var minutes = totalMinutes % 60;

            var totalHour = Hour + extraHour + t.Hour;
            var hours = totalHour % 24;
            var newHour = new Time(hours, minutes, seconds, milliseconds);

            return newHour;
        }

        public bool IsOtherDay(Time t)
        {
            return ToMilliseconds() + t.ToMilliseconds() >= 86400000;

        }


    }
}
