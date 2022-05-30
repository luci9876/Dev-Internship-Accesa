using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface ITraineeChallengeRepository
    {
        IEnumerable<TraineeChallenge> GetTraineeChallenges();

        IEnumerable<TraineeChallenge> GetTraineeChallengesByTraineeId(int traineeId);

        TraineeChallenge GetTraineeChallengeByID(int traineeID, int challengeID);

        TraineeChallenge AddTraineeChallenge(TraineeChallenge traineeChallenge);

        TraineeChallenge RemoveTraineeChallenge(TraineeChallenge traineeChallenge);

        TraineeChallenge UpdateTraineeChallenge(TraineeChallenge traineeChallenge);
    }
}