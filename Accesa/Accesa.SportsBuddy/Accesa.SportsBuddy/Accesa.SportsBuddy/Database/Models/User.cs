using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class User
    {
        public User()
        {
            Challenges = new HashSet<Challenge>();
            Events = new HashSet<Event>();
            Favorites = new HashSet<Favorite>();
            JoinEventCreatedBySportCenters = new HashSet<JoinEventCreatedBySportCenter>();
            JoinEvents = new HashSet<JoinEvent>();
            Reviews = new HashSet<Review>();
            TraineeChallenges = new HashSet<TraineeChallenge>();
            TraineeTrainingPrograms = new HashSet<TraineeTrainingProgram>();
            Trainers = new HashSet<Trainer>();
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
        public int Score { get; set; }

        public virtual Address AddressNavigation { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Challenge> Challenges { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<JoinEventCreatedBySportCenter> JoinEventCreatedBySportCenters { get; set; }
        public virtual ICollection<JoinEvent> JoinEvents { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<TraineeChallenge> TraineeChallenges { get; set; }
        public virtual ICollection<TraineeTrainingProgram> TraineeTrainingPrograms { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
