using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class TraineeTrainingProgram
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public int TrainingProgramId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual User Trainee { get; set; }
        public virtual TrainingProgram TrainingProgram { get; set; }
    }
}
