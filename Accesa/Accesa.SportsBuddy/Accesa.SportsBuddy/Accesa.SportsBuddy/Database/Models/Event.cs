using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class Event
    {
        public Event()
        {
            JoinEvents = new HashSet<JoinEvent>();
        }

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Goal { get; set; }
        public int AddressId { get; set; }
        public DateTime StartDate { get; set; }
        public string Duration { get; set; }

        public virtual Address Address { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<JoinEvent> JoinEvents { get; set; }
    }
}
