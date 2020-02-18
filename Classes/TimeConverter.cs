namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            var berlinClock = new BerlinClock();
            var berlinClockTime = new BerlinClockTime(aTime);
            
            berlinClock.SetTime(berlinClockTime);

            return berlinClock.ToString();
        }
    }
}
