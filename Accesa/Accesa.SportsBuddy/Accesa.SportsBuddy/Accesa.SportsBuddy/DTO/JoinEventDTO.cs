using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.DTO
{
    public class JoinEventDTO
    {
        public int EventId { get; set; }
        public int UserId { get; set; }

        public virtual EventDTO Event { get; set; }
        public virtual TraineeDTO User { get; set; }
    }
}
