using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class EventAttendee
    {
        public int EventAttendeeId { get; set; }
        public int EventId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Event Event { get; set; }
    }
}
