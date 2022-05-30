using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class Trainer
    {
        public Trainer()
        {
            TrainerSportCenters = new HashSet<TrainerSportCenter>();
            TrainerTrainingPrograms = new HashSet<TrainerTrainingProgram>();
        }

        public int Id { get; set; }
        public bool? IsAvailable { get; set; }
        public decimal? Rating { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TrainerSportCenter> TrainerSportCenters { get; set; }
        public virtual ICollection<TrainerTrainingProgram> TrainerTrainingPrograms { get; set; }
    }
}
