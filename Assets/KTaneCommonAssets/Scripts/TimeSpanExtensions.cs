using System;

namespace Assets.Scripts
{
    internal static class TimeSpanExtensions
    {
        public static string MinutesAndSecondsFormat(this TimeSpan timeSpan)
        {
            return String.Format(@"{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }
    }
}