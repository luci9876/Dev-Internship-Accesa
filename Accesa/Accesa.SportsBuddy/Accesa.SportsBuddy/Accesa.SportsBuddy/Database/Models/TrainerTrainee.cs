using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class TrainerTrainee
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int TraineeId { get; set; }

        public virtual Trainee Trainee { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
