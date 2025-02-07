using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Antikythera.Position
{
    public class Time //: DateTime
    {
        //public double Movement { get; set; }
        public double Second { get; set; }
        public double Minute { get; set; }
        public double Hour { get; set; }
        public double Day { get; set; } // Determined by the sun.
        public double Month { get; set; } // Determined by the moon.
        public double Year { get; set; } // Determined by the sun.
        private double PeriodInput { get; set; }
        private object[] Args { get; set; }
        //public Time Ticker = new Time();
        public Timer Timer = new Timer();

        public Time()
        {
            Second = DateTime.Now.Second;
            Minute = DateTime.Now.Minute;
            Hour = DateTime.Now.Hour;
            Day = DateTime.Now.Day;
            Month = DateTime.Now.Month;
            Year = DateTime.Now.Year;
            //timer.Interval = 1000;
            //timer.Start();
            //timer.Tick += new EventHandler(TimerTick);
            //Ticker.TimeTick += new EventHandler(Ticker_TimeTick);
        }

        void TimerTick(object sender, EventArgs e)
        {
            if (Timer.Interval == 1000)
            {
                Timer.Stop();
            }
        }
        public void Wait(int seconds)
        {
            var milliseconds = 1000 * seconds;

            Timer.Interval = milliseconds;
            Timer.Start();
            Timer.Tick += new EventHandler(TimerTick);
        }



        //public void Wait(int seconds)
        //{
        //    timer.Tick += new EventHandler(TimerTick);
        //    timer.Interval = new TimeSpan(0, 0, seconds);
        //    timer.Start();
        //}
        //private void TimerTick(object sender, EventArgs e)
        //{
        //    timer.Stop();
        //    timer -= TimerTick;
        //    timer = null;
        //    // DO SOMETHING
        //}




        //void Ticker_TimeTick(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //public event EventHandler TimeTick;

        void MoveTime(object sender, EventArgs e)
        {
            //var d = particle.Second + 1;
        }

       
        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> class.
        /// </summary>
        /// <param name="periodInput">The type of the period passed into time.</param>
        /// <param name="args">The args, where the string value is either 'seconds', 'minutes', 'hours', or 'days'.</param>
        public Time(double periodInput, params object[] args)
        {
            PeriodInput = periodInput;
            Args = args;
            SortTemporal(PeriodInput, args[0]);
        }

        public Time(double second, double minute, double hour)
        {
            Second = second;
            Minute = minute;
            Hour = hour;
        }

        public static Time operator +(Time toAdd)
        {
            //Add ToAdd to a new instance of Time and return it.

            return null; //Take this out...
        }
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that formats time into a 00:00:00 instance.
        /// </returns>
        public override string ToString()
        {
            var retString = new StringBuilder();

            retString.Append(Hour.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + ":" + Minute.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + ":" + Second.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'));

            return retString.ToString();
        }
        /// <summary>
        /// Sorts the temporal value based on an input and the segment arguments.
        /// </summary>
        /// <param name="value">The value to be temporally sorted.</param>
        /// <param name="args">The argument of the segment of time to be sorted.</param>
        /// <returns></returns>
        public double SortTemporal(double value, object args)
        {
            switch (args.ToString())
            {
                case "seconds":
                    Second = value;
                    value = Second / 60;
                    Minute = value;
                    var valueHour = value / 60;
                    Hour = valueHour;
                    return Day = Hour / 24;
                case "minutes":
                    Minute = value;
                    var valueSecond = value * 60;
                    Second = valueSecond;
                    value = Minute / 60;
                    Hour = value;
                    var valueDay = value / 24;
                    return Day = valueDay;
                case "hours":
                    Hour = value;
                    var valueMinute = value * 60;
                    Minute = valueMinute;
                    valueSecond = Minute * 60;
                    Second = valueSecond;
                    return Day = Hour / 24;
                case "days":
                    return Day = value;
                case "months":
                    return Month = value;
                case "years":
                    return Year = value;
            }
            return value;
        }

        /// <summary>
        /// Allows an <see cref="T:System.Object"/> to attempt to free resources and perform other cleanup operations before the <see cref="T:System.Object"/> is reclaimed by garbage collection.
        /// </summary>
        ~Time()
        {
            Timer.Stop();
        }
    }
}
