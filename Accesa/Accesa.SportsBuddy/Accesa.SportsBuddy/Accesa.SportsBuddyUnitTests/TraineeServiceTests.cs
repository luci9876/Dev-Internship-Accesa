
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace Accesa.SportsBuddyUnitTests
{
    public class Tests
    {

        private TraineeService traineeService;
        private Mock<ITraineeRepository> traineeRepositoryMock;

        [SetUp]
        public void Setup()
        {
            traineeRepositoryMock = new Mock<ITraineeRepository>(MockBehavior.Loose);
        }

        [Test]
        public void ShouldAddTrainee()
        {
            Role role = new Role { Id = 2, Name = "Trainee" };
            var trainee = new User { Id = 1, FirstName = "first", LastName = "last", BirthDate = new DateTime(1998, 04, 30), Gender = "F", PhoneNumber = "122224", Email = "ana@gmail.com", Password = "parola", Address = 1, CreatedAt = new DateTime(1998, 04, 30), Role = role };

            traineeRepositoryMock.Setup(t => t.AddTrainee(trainee)).Returns(trainee);
            traineeService = new TraineeService(traineeRepositoryMock.Object);
            var result = traineeService.AddTrainee(trainee);
            Assert.AreEqual(result, trainee);
        }

        [Test]
        public void ShouldThrowAddingFailedException()
        {
            Role role = new Role { Id = 0, Name = "Trainee" };
            var trainee = new User { Id = 1, FirstName = "first", LastName = "last", BirthDate = new DateTime(1998, 04, 30), Gender = "F", PhoneNumber = "122224", Email = "ana@gmail.com", Password = "parola", Address = 1, CreatedAt = new DateTime(1998, 04, 30), Role = role };

            traineeRepositoryMock.Setup(t => t.AddTrainee(trainee)).Returns(trainee);
            traineeService = new TraineeService(traineeRepositoryMock.Object);
            var ex = Assert.Throws<Exception>(() => traineeService.AddTrainee(trainee));

            Assert.AreEqual("Adding failed", ex.Message);
        }

        [Test]
        public void ShouldUpdateTrainee_GoodData()
        {
            var trainees = new List<User>() {
                new User { Id = 1, FirstName = "Adelina", LastName = "Sfat", BirthDate = new DateTime(1998, 04, 30), Gender = "F", PhoneNumber = "122224", Email = "adelina@gmail.com", Password = "parola", Address = 1, CreatedAt = new DateTime(2021, 04, 30), RoleId = 2 } }
            ;

            var traineeForUpdate = new User { Id = 1, FirstName = "Adelina", LastName = "Popescu", BirthDate = new DateTime(1998, 04, 30), Gender = "F", PhoneNumber = "122224", Email = "adelina@gmail.com", Password = "parola", Address = 1, CreatedAt = new DateTime(2021, 04, 30), RoleId = 2 };


            traineeRepositoryMock.Setup(t => t.UpdateTrainee(It.IsAny<User>())).Returns<User>(trainee => trainees.Find(t => t.Id == trainee.Id));
            traineeRepositoryMock.Setup(t => t.GetTraineeById(It.IsAny<int>())).Returns<int>(x => trainees.Find(t => t.Id == x));

            traineeService = new TraineeService(traineeRepositoryMock.Object);

            var result = traineeService.UpdateTrainee(traineeForUpdate);

            Assert.AreEqual(result.LastName, traineeForUpdate.LastName);

        }

        [Test]
        public void ShouldNotUpdateTrainee_UndefinedRecord()
        {
            var trainees = new List<User>() {
                new User { Id = 1, FirstName = "Adelina", LastName = "Sfat", BirthDate = new DateTime(1998, 04, 30), Gender = "F", PhoneNumber = "122224", Email = "adelina@gmail.com", Password = "parola", Address = 1, CreatedAt = new DateTime(2021, 04, 30), RoleId = 2 } }
            ;

            var traineeForUpdate = new User { Id = 2, FirstName = "Adelina", LastName = "Popescu", BirthDate = new DateTime(1998, 04, 30), Gender = "F", PhoneNumber = "122224", Email = "adelina@gmail.com", Password = "parola", Address = 1, CreatedAt = new DateTime(2021, 04, 30), RoleId = 2 };


            traineeRepositoryMock.Setup(t => t.UpdateTrainee(It.IsAny<User>())).Returns<User>(trainee => trainees.Find(t => t.Id == trainee.Id));
            traineeRepositoryMock.Setup(t => t.GetTraineeById(It.IsAny<int>())).Returns<int>(x => trainees.Find(t => t.Id == x));

            traineeService = new TraineeService(traineeRepositoryMock.Object);

            var result = Assert.Throws<Exception>(() => traineeService.UpdateTrainee(traineeForUpdate));

            Assert.AreEqual(result.Message, "The record doesn't exist");
        }

        [Test]
        public void ShouldNotUpdateTrainee_InvalidRoleId()
        {
            var trainees = new List<User>() {
                new User { Id = 1, FirstName = "Adelina", LastName = "Sfat", BirthDate = new DateTime(1998, 04, 30), Gender = "F", PhoneNumber = "122224", Email = "adelina@gmail.com", Password = "parola", Address = 1, CreatedAt = new DateTime(2021, 04, 30), RoleId = 5 } }
            ;

            var traineeForUpdate = new User { Id = 1, FirstName = "Adelina", LastName = "Popescu", BirthDate = new DateTime(1998, 04, 30), Gender = "F", PhoneNumber = "122224", Email = "adelina@gmail.com", Password = "parola", Address = 1, CreatedAt = new DateTime(2021, 04, 30), RoleId = 2 };


            traineeRepositoryMock.Setup(t => t.UpdateTrainee(It.IsAny<User>())).Returns<User>(trainee => trainees.Find(t => t.Id == trainee.Id));
            traineeRepositoryMock.Setup(t => t.GetTraineeById(It.IsAny<int>())).Returns<int>(x => trainees.Find(t => t.Id == x));
            traineeService = new TraineeService(traineeRepositoryMock.Object);

            var result = Assert.Throws<Exception>(() => traineeService.UpdateTrainee(traineeForUpdate));

            Assert.AreEqual(result.Message, "Invalid role id");
        }


        [Test]
        public void ShouldDeleteTrainee()
        {
            Role role = new Role { Id = 2, Name = "Trainee" };
            User trainee = new User { Id = 1, FirstName = "Sustic", LastName = "Alessandro", BirthDate = new DateTime(1998, 04, 30), Gender = "M", PhoneNumber = "222225", Email = "alessandro@gmail.com", Password = "password", Address = 1, CreatedAt = new DateTime(1998, 04, 30), Role = role };

            traineeRepositoryMock.Setup(t => t.AddTrainee(trainee)).Returns(trainee);
            traineeRepositoryMock.Setup(t => t.DeleteTrainee(trainee.Id));
            traineeRepositoryMock.Setup(t => t.GetTraineeById(trainee.Id)).Returns(trainee);
            traineeService = new TraineeService(traineeRepositoryMock.Object);


            traineeService.AddTrainee(trainee);
            try
            {
                traineeService.DeleteTrainee(trainee.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }

        }

        [Test]
        public void ShouldThrowDeleteFailedException()
        {
            Role role = new Role { Id = 2, Name = "Trainee" };
            User trainee = new User { Id = 1, FirstName = "first", LastName = "last", BirthDate = new DateTime(1998, 04, 30), Gender = "F", PhoneNumber = "122224", Email = "ana@gmail.com", Password = "parola", Address = 1, CreatedAt = new DateTime(1998, 04, 30), Role = role };
            int nonExistentID = 12;

            traineeRepositoryMock.Setup(t => t.DeleteTrainee(trainee.Id));
            traineeRepositoryMock.Setup(t => t.GetTraineeById(trainee.Id)).Returns(trainee);
            traineeService = new TraineeService(traineeRepositoryMock.Object);

            var exception = Assert.Throws<Exception>(() => traineeService.DeleteTrainee(nonExistentID));
            Assert.AreEqual("Delete failed", exception.Message);
        }
    }
}