using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.DTO
{
    public class TraineeChallengeDTO
    {
        public int ChallengeId { get; set; }
        public int TraineeId { get; set; }
        public bool IsFinished { get; set; }
        public string Proof { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}