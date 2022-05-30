using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class Trainee
    {
        public Trainee()
        {
            Favorites = new HashSet<Favorite>();
            Reviews = new HashSet<Review>();
            TraineeTrainingPrograms = new HashSet<TraineeTrainingProgram>();
            TrainerTrainees = new HashSet<TrainerTrainee>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RoleId { get; set; }

        public virtual Address AddressNavigation { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<TraineeTrainingProgram> TraineeTrainingPrograms { get; set; }
        public virtual ICollection<TrainerTrainee> TrainerTrainees { get; set; }
    }
}
