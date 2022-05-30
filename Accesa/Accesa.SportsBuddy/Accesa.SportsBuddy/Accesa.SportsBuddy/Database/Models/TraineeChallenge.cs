using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class TraineeChallenge
    {
        public int ChallengeId { get; set; }
        public int TraineeId { get; set; }
        public bool IsFinished { get; set; }
        public string Proof { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Challenge Challenge { get; set; }
        public virtual User Trainee { get; set; }
    }
}
