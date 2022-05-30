//using System;
//using Moq;
//using Accesa.SportsBuddy.Database.Models;
//using Accesa.SportsBuddy.Services;
//using NUnit.Framework;
//using Accesa.SportsBuddy.Services.Interfaces;
//using AutoMapper;
//using Accesa.SportsBuddy.Controllers;
//using Accesa.SportsBuddy.DTO;
//using Microsoft.AspNetCore.Mvc;

//namespace Accesa.SportsBuddyUnitTests
//{
//    class TraineeControllerTests
//    {
//        private TraineeController traineeController;
//        private Mock<ITraineeService> traineeServiceMock;
//        private Mock<IMapper> mapperMock;


//        [SetUp]
//        public void Setup()
//        {
//            traineeServiceMock = new Mock<ITraineeService>();
//            mapperMock = new Mock<IMapper>();
//        }

//        [Test]
//        public void ShouldAddTrainee()
//        {
//            var traineeDTO = new TraineeDTO { Id = 1, FirstName = "first", LastName = "last", BirthDate = new DateTime(1998, 04, 30), Gender = "F", PhoneNumber = "122224", Email = "ana@gmail.com", Password = "parola", CreatedAt = new DateTime(1998, 04, 30) };
//            var trainee = new User { Id = 1, FirstName = "first", LastName = "last", BirthDate = new DateTime(1998, 04, 30), Gender = "F", PhoneNumber = "122224", Email = "ana@gmail.com", Password = "parola", Address = 1, CreatedAt = new DateTime(1998, 04, 30), RoleId = 1 };

//            mapperMock.Setup(t => t.Map<User>(traineeDTO)).Returns(trainee);
//            traineeServiceMock.Setup(t => t.AddTrainee(trainee)).Returns(trainee);
//            mapperMock.Setup(t => t.Map<TraineeDTO>(trainee)).Returns(traineeDTO);
//            traineeController = new TraineeController(traineeServiceMock.Object, mapperMock.Object);

//            var result = traineeController.AddTrainee(traineeDTO);
//            var okResult = result as OkObjectResult;

//            Assert.IsNotNull(okResult);
//            Assert.AreEqual(200, okResult.StatusCode);
//        }

//        [Test]
//        public void ShouldDeleteTrainee()
//        {
//            var traineeDTO = new TraineeDTO { Id = 1, FirstName = "Sustic", LastName = "Alessandro", BirthDate = new DateTime(1998, 04, 30), Gender = "M", PhoneNumber = "222225", Email = "alessandro@gmail.com", Password = "password", CreatedAt = new DateTime(1998, 04, 30) };
//            var trainee = new User { Id = 1, FirstName = "Sustic", LastName = "Alessandro", BirthDate = new DateTime(1998, 04, 30), Gender = "M", PhoneNumber = "222225", Email = "alessandro@gmail.com", Password = "password", Address = 1, CreatedAt = new DateTime(1998, 04, 30), RoleId = 1 };

//            mapperMock.Setup(t => t.Map<User>(traineeDTO)).Returns(trainee);
//            traineeServiceMock.Setup(t => t.AddTrainee(trainee)).Returns(trainee);
//            traineeServiceMock.Setup(t => t.DeleteTrainee(trainee.Id));
//            traineeServiceMock.Setup(t => t.GetTraineeById(trainee.Id)).Returns(trainee);
//            mapperMock.Setup(t => t.Map<TraineeDTO>(trainee)).Returns(traineeDTO);
//            traineeController = new TraineeController(traineeServiceMock.Object, mapperMock.Object);

//            traineeController.AddTrainee(traineeDTO);
//            var okResult = traineeController.DeleteTrainee(traineeDTO.Id);
//            IActionResult expectedResult = new OkResult();

//            Assert.IsTrue(okResult.GetType().Equals(expectedResult.GetType()));
//        }

//        [Test]
//        public void ShouldDeleteTraineeError()
//        {
//            var traineeDTO = new TraineeDTO { Id = 1, FirstName = "Sustic", LastName = "Alessandro", BirthDate = new DateTime(1998, 04, 30), Gender = "M", PhoneNumber = "222225", Email = "alessandro@gmail.com", Password = "password", CreatedAt = new DateTime(1998, 04, 30) };
//            var trainee = new User { Id = 1, FirstName = "Sustic", LastName = "Alessandro", BirthDate = new DateTime(1998, 04, 30), Gender = "M", PhoneNumber = "222225", Email = "alessandro@gmail.com", Password = "password", Address = 1, CreatedAt = new DateTime(1998, 04, 30), RoleId = 1 };

//            mapperMock.Setup(t => t.Map<User>(traineeDTO)).Returns(trainee);
//            traineeServiceMock.Setup(t => t.DeleteTrainee(trainee.Id));
//            traineeServiceMock.Setup(t => t.GetTraineeById(trainee.Id)).Returns(trainee);
//            mapperMock.Setup(t => t.Map<TraineeDTO>(trainee)).Returns(traineeDTO);
//            traineeController = new TraineeController(traineeServiceMock.Object, mapperMock.Object);

//            int nonExistentID = 0;
//            var notFound = traineeController.DeleteTrainee(nonExistentID);
//            var notFoundObject = notFound as NotFoundObjectResult;

//            Assert.AreEqual(404, notFoundObject.StatusCode);
//        }
//    }
//}