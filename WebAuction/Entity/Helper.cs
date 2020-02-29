using System;

namespace Entity
{
    public class Helper
    {
        public static string GetCountdown(DateTime Start, DateTime End)
        {
            if (Start < End)
            {
                var days = End - Start;
                if (days.Days > 0)
                {
                    return days.Days.ToString() + " days";
                }
                if (days.Hours > 0)
                {
                    return days.Hours.ToString() + " hours";
                }
                return days.Minutes.ToString() + " minutes";
            }
            return "Ended";
        }
    }
}
