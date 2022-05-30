using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.DTO
{
    public class JoinEventCreatedBySportCenterDTO
    {
        public int EventId { get; set; }
        public int UserId { get; set; }

        public virtual EventCreatedBySportCenterDTO Event { get; set; }
        public virtual TraineeDTO User { get; set; }
    }
}
