namespace BerlinClock.Classes
{
    public class BerlinClock
    {
        public char[] SecondsRow { get; set; } = {'Y'};
        public char[] FiveHourLampRow { get; set; } = {'R', 'R', 'R', 'R'};
        public char[] OneHourLampRow { get; set; } = {'R', 'R', 'R', 'R'};
        public char[] FiveMinuteLampRow { get; set; } = {'Y', 'Y', 'R', 'Y', 'Y', 'R', 'Y', 'Y', 'R', 'Y', 'Y'};
        public char[] OneMinuteLampRow { get; set; } = {'Y', 'Y', 'Y', 'Y'};

        public override string ToString()
        {
            return $"{new string(this.SecondsRow)}\r\n" +
                   $"{new string(this.FiveHourLampRow)}\r\n" +
                   $"{new string(this.OneHourLampRow)}\r\n" +
                   $"{new string(this.FiveMinuteLampRow)}\r\n" +
                   $"{new string(this.OneMinuteLampRow)}";
        }

        public void SetTime(BerlinClockTime dateTime)
        {
            setSeconds(dateTime.Second);

            setHours(dateTime.Hour);

            setMinutes(dateTime.Minute);
        }

        private void setSeconds(int seconds)
        {
            var lampOn = seconds % 2 == 0;
            this.SecondsRow[0] = lampOn ? 'Y' : 'O';
        }

        private void setHours(int hours)
        {
            const int hoursPerLamp = 5;

            var fiveHourLampsTurnedOnCount = hours / hoursPerLamp;
            for (var i = 0; i < this.FiveHourLampRow.Length; i++)
            {
                this.FiveHourLampRow[i] = i < fiveHourLampsTurnedOnCount ? 'R' : 'O';
            }

            var oneHourLampsTurnedOnCount = hours % hoursPerLamp;
            for (var i = 0; i < this.OneHourLampRow.Length; i++)
            {
                this.OneHourLampRow[i] = i < oneHourLampsTurnedOnCount ? 'R' : 'O';
            }
        }

        private void setMinutes(int minutes)
        {
            const int minutesPerLamp = 5;

            var fiveMinLampsTurnedOnCount = minutes / minutesPerLamp;
            for (var i = 0; i < this.FiveMinuteLampRow.Length; i++)
            {
                this.FiveMinuteLampRow[i] = i < fiveMinLampsTurnedOnCount ? i % 3 == 2 ? 'R' : 'Y' : 'O';
            }

            var oneMinLampsTurnedOnCount = minutes % minutesPerLamp;
            for (var i = 0; i < this.OneMinuteLampRow.Length; i++)
            {
                this.OneMinuteLampRow[i] = i < oneMinLampsTurnedOnCount ? 'Y' : 'O';
            }
        }
    }
}