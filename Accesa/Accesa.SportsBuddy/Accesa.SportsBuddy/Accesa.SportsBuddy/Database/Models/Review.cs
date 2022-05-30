using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public decimal? Rating { get; set; }
        public string Comment { get; set; }
        public int TraineeId { get; set; }
        public int TrainingId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User Trainee { get; set; }
        public virtual TrainingProgram Training { get; set; }
    }
}
