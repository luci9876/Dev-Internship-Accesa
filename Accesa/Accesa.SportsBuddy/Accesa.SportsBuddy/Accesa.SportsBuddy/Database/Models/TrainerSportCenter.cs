using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class TrainerSportCenter
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int SportCenterId { get; set; }

        public virtual SportCenter SportCenter { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
