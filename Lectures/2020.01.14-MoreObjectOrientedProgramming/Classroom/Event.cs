using System;

namespace Classroom
{
    public class Event
    {
        public Event(DateTime startDateTime, TimeSpan duration)
        {
            (StartDateTime, Duration) = (startDateTime, duration);
        }

        public DateTime StartDateTime { get; set; }

        TimeSpan _TimeSpan;
        public TimeSpan Duration {
            get
            {
                return _TimeSpan;
            }
            set
            {
                if (value.TotalSeconds == 0)
                {
                    throw new ArgumentException(
                        $"The { nameof(Duration)} must be greater than 0", nameof(value));
                }
                _TimeSpan = value;
            }
        }
    }
}
