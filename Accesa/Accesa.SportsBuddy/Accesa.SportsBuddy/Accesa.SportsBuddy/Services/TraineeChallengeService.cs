using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services
{
    public class TraineeChallengeService : ITraineeChallengeService
    {
        private readonly ITraineeChallengeRepository _traineeChallengeRepository;

        public TraineeChallengeService(ITraineeChallengeRepository traineeChallengeRepository)
        {

            _traineeChallengeRepository = traineeChallengeRepository;
        }

        public TraineeChallenge AddTraineeChallenge(TraineeChallenge traineeChallenge)
        {
            try
            {
                TraineeChallenge traineeChallengeReturned = _traineeChallengeRepository.GetTraineeChallengeByID(traineeChallenge.TraineeId, traineeChallenge.ChallengeId);
                if (traineeChallengeReturned != null)
                {
                    throw new Exception("This trainee challenge already exists!");
                }

                return _traineeChallengeRepository.AddTraineeChallenge(traineeChallenge);
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding operation failed : {ex.Message}");
            }

        }

        public TraineeChallenge GetTraineeChallengeByID(int traineeID, int challengeID)
        {
            try
            {
                return _traineeChallengeRepository.GetTraineeChallengeByID(traineeID, challengeID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation by id failed : {ex.Message}");
            }
        }

        public IEnumerable<TraineeChallenge> GetTraineeChallenges()
        {
            try
            {
                return _traineeChallengeRepository.GetTraineeChallenges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation failed : {ex.Message}");
            }
        }

        public IEnumerable<TraineeChallenge> GetTraineeChallengesByTraineeId(int traineeId)
        {
            return _traineeChallengeRepository.GetTraineeChallengesByTraineeId(traineeId);
        }

        public TraineeChallenge RemoveTraineeChallenge(int traineeID, int challengeID)
        {
            try
            {
                TraineeChallenge traineeChallenge = _traineeChallengeRepository.GetTraineeChallengeByID(traineeID, challengeID);
                if (traineeChallenge == null)
                {
                    throw new Exception("Trainee challenge with this id doesn't exist!");
                }
                return _traineeChallengeRepository.RemoveTraineeChallenge(traineeChallenge);
            }
            catch (Exception ex)
            {
                throw new Exception($"Remove operation failed : {ex.Message}");
            }
        }

        public TraineeChallenge UpdateTraineeChallenge(TraineeChallenge traineeChallenge)
        {
            try
            {
                TraineeChallenge traineeChallengeToUpdate = _traineeChallengeRepository.GetTraineeChallengeByID(traineeChallenge.TraineeId, traineeChallenge.ChallengeId);
                if (traineeChallengeToUpdate == null)
                {
                    throw new Exception("Trainee challenge with this id doesn't exist!");
                }

                traineeChallengeToUpdate.Proof = traineeChallenge.Proof;
                traineeChallengeToUpdate.IsFinished = traineeChallenge.IsFinished;
                traineeChallengeToUpdate.EndDate = traineeChallenge.EndDate;
                traineeChallengeToUpdate.StartDate = traineeChallenge.StartDate;
                traineeChallengeToUpdate.ChallengeId = traineeChallenge.ChallengeId;
                traineeChallengeToUpdate.TraineeId = traineeChallenge.TraineeId;

                return _traineeChallengeRepository.UpdateTraineeChallenge(traineeChallengeToUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Update operation failed! {ex.Message}");
            }
        }
    }
}