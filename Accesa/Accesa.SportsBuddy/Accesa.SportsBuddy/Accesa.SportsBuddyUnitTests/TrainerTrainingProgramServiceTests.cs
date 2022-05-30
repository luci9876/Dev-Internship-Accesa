//using Accesa.SportsBuddy.Database.Models;
//using Accesa.SportsBuddy.Repositories.Interfaces;
//using Accesa.SportsBuddy.Services;
//using Accesa.SportsBuddy.Services.Interfaces;
//using Moq;
//using NUnit.Framework;
//using System.Collections.Generic;
//using System.Linq;

//namespace Accesa.SportsBuddyUnitTests
//{
//    public class TrainerTrainingProgramServiceTests
//    {

//        private ITrainerTrainingProgramService _trainerTrainingProgramService;
//        private Mock<ITrainerTrainingProgramRepository> _trainerTrainingProgramRepositoryMock;


//        [SetUp]
//        public void Setup()
//        {
//            _trainerTrainingProgramRepositoryMock = new Mock<ITrainerTrainingProgramRepository>();
//            _trainerTrainingProgramRepositoryMock = new Mock<ITrainerTrainingProgramRepository>(MockBehavior.Loose);
//        }
//        [Test]
//        public void ShouldGet_TrainingProgram()
//        {
//            var trainings = new List<TrainerTrainingProgram>() {new TrainerTrainingProgram { Id = 1, TrainingProgramId=1,TrainerId=1} };
//            var trainingProgramId = 1;
//            _trainerTrainingProgramRepositoryMock.Setup(t => t.GetTrainingInfoById(It.IsAny<int>())).Returns<int>(x => trainings.Find(t => t.Id == x));
//            _trainerTrainingProgramService = new TrainerTrainingProgramService(_trainerTrainingProgramRepositoryMock.Object);
//            var result = _trainerTrainingProgramService.GetTrainingInfoById(trainingProgramId);
//            Assert.NotNull(result);
//        }
//          [Test]
//          public void ShouldGet_TrainingsProgram()
//          {
//            var trainings = new List<TrainerTrainingProgram>() { new TrainerTrainingProgram { Id = 1, TrainingProgramId = 1, TrainerId = 1 }, new TrainerTrainingProgram { Id = 2, TrainingProgramId = 2, TrainerId = 2 } };
//            _trainerTrainingProgramRepositoryMock.Setup(t => t.GetTrainingsInfo()).Returns(trainings);
//            _trainerTrainingProgramService = new TrainerTrainingProgramService(_trainerTrainingProgramRepositoryMock.Object);
//            var result = _trainerTrainingProgramService.GetTrainingsInfo();
//            Assert.AreEqual(result.Count(), 2);

//        }
//        [Test]
//        public void ShouldNotGet_TrainingProgram()
//        {
//            var trainings = new List<TrainerTrainingProgram>() { new TrainerTrainingProgram { Id = 1, TrainingProgramId = 1, TrainerId = 1 } };
//            var trainingProgramId = 0;
//            _trainerTrainingProgramRepositoryMock.Setup(t => t.GetTrainingInfoById(It.IsAny<int>())).Returns<int>(x => trainings.Find(t => t.Id == x));
//            _trainerTrainingProgramService = new TrainerTrainingProgramService(_trainerTrainingProgramRepositoryMock.Object);
//            var result = _trainerTrainingProgramService.GetTrainingInfoById(trainingProgramId);
//            Assert.Null(result);
//        }
//    }
//}
