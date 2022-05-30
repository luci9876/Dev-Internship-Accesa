using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class TrainerTrainingProgram
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int TrainingProgramId { get; set; }

        public virtual Trainer Trainer { get; set; }
        public virtual TrainingProgram TrainingProgram { get; set; }
    }
}
