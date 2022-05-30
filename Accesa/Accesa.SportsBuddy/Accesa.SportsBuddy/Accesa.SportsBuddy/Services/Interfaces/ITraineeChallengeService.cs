using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface ITraineeChallengeService
    {
        IEnumerable<TraineeChallenge> GetTraineeChallenges();

        TraineeChallenge GetTraineeChallengeByID(int traineeID, int challengeID);
        IEnumerable<TraineeChallenge> GetTraineeChallengesByTraineeId(int traineeId);

        TraineeChallenge AddTraineeChallenge(TraineeChallenge traineeChallenge);

        TraineeChallenge RemoveTraineeChallenge(int traineeID, int challengeID);

        TraineeChallenge UpdateTraineeChallenge(TraineeChallenge traineeChallenge);
    }
}