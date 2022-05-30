using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services
{
    public class ChallengeService : IChallengeService
    {

        private readonly IChallengeRepository _challengeRepository;

        public ChallengeService(IChallengeRepository challengeRepository)
        {

            _challengeRepository = challengeRepository;
        }

        public Challenge AddChallenge(Challenge challenge)
        {
            try
            {
                return _challengeRepository.AddChallenge(challenge);
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding operation failed : {ex.Message}");
            }
        }

        public IEnumerable<Challenge> GetChallengeByAuthor(int authorId)
        {
            try
            {
                return _challengeRepository.GetChallengeByAuthor(authorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation by id failed : {ex.Message}");
            }
        }

        public Challenge GetChallengeByID(int id)
        {
            try
            {
                return _challengeRepository.GetChallengeByID(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation by id failed : {ex.Message}");
            }
        }

        public IEnumerable<Challenge> GetChallenges()
        {
            try
            {
                return _challengeRepository.GetChallenges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation failed : {ex.Message}");
            }
        }

        public Challenge RemoveChallenge(int challengeID)
        {
            try
            {
                Challenge challenge = _challengeRepository.GetChallengeByID(challengeID);
                if (challenge == null)
                {
                    throw new Exception("Challenge with this id doesn't exists!");
                }
                return _challengeRepository.RemoveChallenge(challenge);
            }
            catch (Exception ex)
            {
                throw new Exception($"Remove operation failed : {ex.Message}");
            }
        }

        public Challenge UpdateChallenge(Challenge challenge)
        {
            try
            {
                Challenge challengeToUpdate = _challengeRepository.GetChallengeByID(challenge.Id);
                if (challengeToUpdate == null)
                {
                    throw new Exception("Challenge with this id doesn't exists!");
                }

                challengeToUpdate.Title = challenge.Title;
                challengeToUpdate.Description = challenge.Description;
                challengeToUpdate.TrackedOutcome = challenge.TrackedOutcome;

                return _challengeRepository.UpdateChallenge(challengeToUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Update operation failed! {ex.Message}");
            }
        }
    }
}