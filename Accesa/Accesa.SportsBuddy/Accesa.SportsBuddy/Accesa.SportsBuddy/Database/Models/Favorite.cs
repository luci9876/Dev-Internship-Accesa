using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public int TrainingId { get; set; }

        public virtual User Trainee { get; set; }
        public virtual TrainingProgram Training { get; set; }
    }
}
