using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class Challenge
    {
        public Challenge()
        {
            TraineeChallenges = new HashSet<TraineeChallenge>();
        }

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TrackedOutcome { get; set; }

        public virtual User Author { get; set; }
        public virtual ICollection<TraineeChallenge> TraineeChallenges { get; set; }
    }
}
