using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class JoinEvent
    {
        public int EventId { get; set; }
        public int UserId { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
