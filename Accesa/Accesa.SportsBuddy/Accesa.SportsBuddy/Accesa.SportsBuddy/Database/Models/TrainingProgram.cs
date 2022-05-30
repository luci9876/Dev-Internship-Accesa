using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class TrainingProgram
    {
        public TrainingProgram()
        {
            Favorites = new HashSet<Favorite>();
            Reviews = new HashSet<Review>();
            TraineeTrainingPrograms = new HashSet<TraineeTrainingProgram>();
            TrainerTrainingPrograms = new HashSet<TrainerTrainingProgram>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public string Description { get; set; }
        public string RecommendedSteps { get; set; }
        public string Location { get; set; }
        public int? SportCenterId { get; set; }
        public string Duration { get; set; }
        public decimal Rating { get; set; }

        public virtual SportCenter SportCenter { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<TraineeTrainingProgram> TraineeTrainingPrograms { get; set; }
        public virtual ICollection<TrainerTrainingProgram> TrainerTrainingPrograms { get; set; }
    }
}
