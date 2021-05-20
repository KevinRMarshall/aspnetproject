using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class Event
    {
        public Event()
        {
            EventAttendee = new HashSet<EventAttendee>();
        }

        public int EventId { get; set; }
        public int GameId { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }

        public virtual Game Game { get; set; }
        public virtual ICollection<EventAttendee> EventAttendee { get; set; }
    }
}
