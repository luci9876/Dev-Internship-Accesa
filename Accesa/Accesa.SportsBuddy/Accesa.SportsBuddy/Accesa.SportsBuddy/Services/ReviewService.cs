using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System.Collections.Generic;

namespace Accesa.SportsBuddy.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly ITrainingProgramService _trainingProgramService;
        private readonly ITrainerTrainingProgramService _trainerTrainingProgramService;
        private readonly ITrainerRepository _trainerRepository;

        public ReviewService(IReviewRepository reviewRepository,
            ITrainingProgramService trainingProgramService,
            ITrainerTrainingProgramService trainerTrainingProgramService,
            ITrainerRepository trainerRepository)
        {
            _reviewRepository = reviewRepository;
            _trainingProgramService = trainingProgramService;
            _trainerTrainingProgramService = trainerTrainingProgramService;
            _trainerRepository = trainerRepository;
        }

        public IEnumerable<Review> GetReviewsByTrainingId(int id)
        {
            return _reviewRepository.GetReviewsByTrainingId(id);
        }

        public void AddReviewForUser(Review review)
        {
            if (review == null)
                return;

            _reviewRepository.AddReviewForUser(review);

            var training = _trainingProgramService.GetTrainingProgramById(review.TrainingId);
            var reviewsCount = _reviewRepository.GetReviewsCountByTrainingId(review.TrainingId);
            training.Rating = (decimal)((training.Rating * (reviewsCount - 1) + review.Rating) / reviewsCount);
            _trainingProgramService.UpdateTrainingProgram(training);

            var trainerTrainingInfo = _trainerTrainingProgramService.GetTrainingInfoById(review.TrainingId);
            var trainingsCount = _trainerTrainingProgramService.GetTrainingProgramsCountByTrainerId(trainerTrainingInfo.TrainerId);
            var trainer = _trainerRepository.GetTrainerById(trainerTrainingInfo.TrainerId);
            trainer.Rating = (decimal)(trainer.Rating * (trainingsCount - 1) + training.Rating) / trainingsCount;
            _trainerRepository.UpdateTrainer(trainer);
        }
    }
}
