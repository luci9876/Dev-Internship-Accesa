//using Accesa.SportsBuddy.Database.Models;
//using Accesa.SportsBuddy.Services;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Moq;
//using Accesa.SportsBuddy.Repositories.Interfaces;
//using Accesa.SportsBuddy.DTO;
//using AutoMapper;
//using Accesa.SportsBuddy.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using Accesa.SportsBuddy.Services.Interfaces;

//namespace Accesa.SportsBuddyUnitTests
//{
//    class TrainerControllerTest
//    {
//        private TrainerController trainerController;
//        private Mock<ITrainerRepository> trainerRepositoryMock;
//        private Mock<IMapper> mapperMock;


//        [SetUp]
//        public void Setup()
//        {
//            trainerRepositoryMock = new Mock<ITrainerRepository>();
//            mapperMock = new Mock<IMapper>();
//        }

//        [Test]
//        public void ShouldAddTrainer()
//        {
//            var trainerDTO = new TrainerDTO { Id = 1, IsAvailable = true, Rating = 8 };
//            var trainer = new Trainer { Id = 1, IsAvailable = true, Rating = 8, UserId = 1 };

//            mapperMock.Setup(trainerTest => trainerTest.Map<Trainer>(trainerDTO)).Returns(trainer);
//            trainerRepositoryMock.Setup(trainerTest => trainerTest.AddTrainer(trainer)).Returns(trainer);
//            mapperMock.Setup(trainerDTOTest => trainerDTOTest.Map<TrainerDTO>(trainer)).Returns(trainerDTO);
//            trainerController = new TrainerController(trainerRepositoryMock.Object, mapperMock.Object);

//            var result = trainerController.AddTrainer(trainerDTO);
//            var okResult = result as OkObjectResult;
//            Assert.IsNotNull(okResult);
//            Assert.AreEqual(200, okResult.StatusCode);
//        }

//        [Test]
//        public void ShouldNotAddTrainer_MissingInfo()
//        {
//            var trainerDTO = new TrainerDTO { Id = 1, IsAvailable = true };
//            var trainer = new Trainer { Id = 1, IsAvailable = true, UserId = 1 };

//            mapperMock.Setup(trainerTest => trainerTest.Map<Trainer>(trainerDTO)).Returns(trainer);
//            trainerRepositoryMock.Setup(trainerTest => trainerTest.AddTrainer(trainer)).Throws(new Exception());
//            mapperMock.Setup(trainerDTOTest => trainerDTOTest.Map<TrainerDTO>(trainer)).Returns(trainerDTO);
//            trainerController = new TrainerController(trainerRepositoryMock.Object, mapperMock.Object);

//            var result = trainerController.AddTrainer(trainerDTO);
//            var badResult = result as BadRequestObjectResult;
//            Assert.IsNotNull(badResult);
//            Assert.AreEqual(400, badResult.StatusCode);
//        }

//        [Test]
//        public void ShouldNotAddTrainer_BadInfo()
//        {
//            var trainerDTO = new TrainerDTO { Id = 1, IsAvailable = true, Rating = 8 };
//            var trainer = new Trainer { Id = -1, IsAvailable = true, Rating = 8, UserId = 1 };

//            mapperMock.Setup(trainerTest => trainerTest.Map<Trainer>(trainerDTO)).Returns(trainer);
//            trainerRepositoryMock.Setup(trainerTest => trainerTest.AddTrainer(trainer)).Throws(new Exception());
//            mapperMock.Setup(trainerDTOTest => trainerDTOTest.Map<TrainerDTO>(trainer)).Returns(trainerDTO);
//            trainerController = new TrainerController(trainerRepositoryMock.Object, mapperMock.Object);

//            var result = trainerController.AddTrainer(trainerDTO);
//            var badResult = result as BadRequestObjectResult;
//            Assert.IsNotNull(badResult);
//            Assert.AreEqual(400, badResult.StatusCode);
//        }

//        [Test]
//        public void DeleteTrainerTest_OkResult()
//        {
//            int deletedId = 1;
//            var controller = new TrainerController(trainerRepositoryMock.Object, mapperMock.Object);
//            var data = controller.DeleteTrainer(deletedId);
//            trainerRepositoryMock.Verify(s => s.DeleteTrainer(deletedId), Times.Once());
//        }

//        [Test]
//        public void DeleteTrainerTest_NotFoundResult()
//        {
//            int deletedId = 0;
//            var controller = new TrainerController(trainerRepositoryMock.Object, mapperMock.Object);
//            var data = controller.DeleteTrainer(deletedId);
//            //trainerRepositoryMock.Verify(s => s.DeleteTrainer(deletedId), Times.Once());

//            var notFoundObject = data as NotFoundObjectResult;
//            Assert.AreEqual(404, notFoundObject.StatusCode);
//        }
//    }
//}
