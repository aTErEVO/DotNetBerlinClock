using System;
using System.Text.RegularExpressions;

namespace BerlinClock.Classes
{
    /// <summary>
    /// Note: 24:00:00 does not exist in C# DateTime representation so instead of converting time string to DateTime type and use its
    /// hour, minutes, seconds properties I have created custom converter.
    /// </summary>
    public class BerlinClockTime
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public BerlinClockTime(string time)
        {
            var regex = new Regex("^(?'hour'[0-2][0-9]):(?'minute'[0-5][0-9]):(?'second'[0-5][0-9])$");

            var matchedGroups = regex.Match(time).Groups;
            if (matchedGroups.Count != 4)
            {
                throw new ArgumentException("Incorrect input string.");
            }

            this.Hour = int.Parse(matchedGroups["hour"].ToString());
            this.Minute = int.Parse(matchedGroups["minute"].ToString());
            this.Second = int.Parse(matchedGroups["second"].ToString());
        }
    }
}