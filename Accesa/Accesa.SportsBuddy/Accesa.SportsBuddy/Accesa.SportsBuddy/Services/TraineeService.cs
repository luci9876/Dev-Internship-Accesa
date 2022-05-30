using Accesa.SportsBuddy.Controllers.Models;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services
{
    public class TraineeService : ITraineeService
    {
        private readonly ITraineeRepository _traineeRepository;

        public TraineeService(ITraineeRepository traineeRepository)
        {
            _traineeRepository = traineeRepository;
        }
        public User AddTrainee(User trainee)
        {
            try
            {
                var result = _traineeRepository.AddTrainee(trainee);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding failed : {ex.StackTrace}");
            }
        }

        public void DeleteTrainee(int id)
        {
            try
            {
                var traineeForDeleteIndex = _traineeRepository.GetTraineeById(id);
                if (traineeForDeleteIndex is null)
                {
                    throw new Exception("Invalid ID");
                }
                _traineeRepository.DeleteTrainee(traineeForDeleteIndex.Id);
            }
            catch (Exception)
            {
                throw new Exception("Delete failed");
            }
        }

        public IEnumerable<User> GetAllTrainees()
        {
            try
            {
                return _traineeRepository.GetAllTrainees();
            }
            catch (Exception)
            {
                throw new Exception("Get failed");
            }
        }

        public IEnumerable<User> GetAllTraineesSortedByScore()
        {
            try
            {
                return _traineeRepository.GetAllTraineesSortedByScore();
            }
            catch (Exception)
            {
                throw new Exception("Get trainees sorted failed");
            }
        }

        public User GetTraineeById(int id)
        {
            try
            {
                var trainee = _traineeRepository.GetTraineeById(id);
                if (trainee == null)
                {
                    throw new Exception("invalid id");
                }
                return trainee;
            }
            catch (Exception)
            {
                throw new Exception("The record doesn't exist");
            }

        }

        public bool HasValidCredentials(UserCredentials info)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(info.Email))
                {
                    throw new Exception("Email can't be empty");
                }
                if (string.IsNullOrWhiteSpace(info.Password))
                {
                    throw new Exception("Password can't be empty");
                }
                var result = _traineeRepository.HasValidCredentials(info);
                return result;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public User UpdateTrainee(User trainee)
        {
            try
            {
                var traineeForUpdate = _traineeRepository.GetTraineeById(trainee.Id);
                if (traineeForUpdate == null)
                {
                    throw new Exception("The record doesn't exist");
                }
                
                traineeForUpdate.FirstName = trainee.FirstName;
                traineeForUpdate.LastName = trainee.LastName;
                traineeForUpdate.BirthDate = trainee.BirthDate;
                traineeForUpdate.Gender = trainee.Gender;
                traineeForUpdate.PhoneNumber = trainee.PhoneNumber;
                traineeForUpdate.Email = trainee.Email;
                traineeForUpdate.Password = trainee.Password;
                traineeForUpdate.AddressNavigation = trainee.AddressNavigation;
                traineeForUpdate.Role = trainee.Role;
                var result = _traineeRepository.UpdateTrainee(traineeForUpdate);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public User UpdateUserScore(int id)
        {
            try
            {
                var traineeForUpdate = _traineeRepository.GetTraineeById(id);
                if (traineeForUpdate == null)
                {
                    throw new Exception("The record doesn't exist");
                }

                const int completedChallengeScore = 10;
                traineeForUpdate.Score = traineeForUpdate.Score + completedChallengeScore;
                var result = _traineeRepository.UpdateTrainee(traineeForUpdate);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                var trainee = _traineeRepository.GetUserByEmail(email);
                if (trainee == null)
                {
                    throw new Exception("invalid email");
                }
                return trainee;
            }
            catch (Exception)
            {
                throw new Exception("The record doesn't exist");
            }

        }
    }
}