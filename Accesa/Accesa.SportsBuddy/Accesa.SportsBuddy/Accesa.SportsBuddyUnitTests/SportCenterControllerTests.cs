using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.DTO;
using AutoMapper;
using Accesa.SportsBuddy.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Accesa.SportsBuddyUnitTests
{
    public class SportCenterControllerTests
    {
        private Mock<ISportCenterRepository> _sportCenterRepositoryMock;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _sportCenterRepositoryMock = new Mock<ISportCenterRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public void ShouldAddSportCenter_HappyFlow()
        {
            var sportCenterDTO = new SportCenterDTO { Id = 1, Name = "sportcenter1", Address = 1 };

            _sportCenterRepositoryMock.Setup(t => t.CreateSportCenter(sportCenterDTO)).Returns(sportCenterDTO);

            var sportCenterController = new SportCenterController(_sportCenterRepositoryMock.Object, _mapper.Object);
            var result = sportCenterController.AddSportCenter(sportCenterDTO);
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void ShouldNotAddSportCenter_MissingInformation()
        {
            var sportCenterDTO = new SportCenterDTO { Id = 1, Address = 1 };

            _sportCenterRepositoryMock.Setup(t => t.CreateSportCenter(sportCenterDTO)).Throws(new Exception());

            var sportCenterController = new SportCenterController(_sportCenterRepositoryMock.Object, _mapper.Object);
            var result = sportCenterController.AddSportCenter(sportCenterDTO);
            var badResult = result as BadRequestResult;

            Assert.IsNotNull(badResult);
            Assert.AreEqual(400, badResult.StatusCode);
        }

        [Test]
        public void ShouldNotAddSportCenter_BadInformation()
        {
            var sportCenterDTO = new SportCenterDTO { Id = -1, Name = "center", Address = 1 };

            _sportCenterRepositoryMock.Setup(t => t.CreateSportCenter(sportCenterDTO)).Throws(new Exception());

            var sportCenterController = new SportCenterController(_sportCenterRepositoryMock.Object, _mapper.Object);
            var result = sportCenterController.AddSportCenter(sportCenterDTO);
            var badResult = result as BadRequestResult;

            Assert.IsNotNull(badResult);
            Assert.AreEqual(400, badResult.StatusCode);
        }
             [Test]
        public void ShouldDeleteSportCenter_HappyFlow()
        {
            int sportCenterId = 11;
            _sportCenterRepositoryMock.Setup(s => s.DeleteSportCenterById(sportCenterId));
            var sportCenterController = new SportCenterController(_sportCenterRepositoryMock.Object, _mapper.Object);
            var result = sportCenterController.DeleteSportCenterById(sportCenterId);
            var statusResult = result as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200,statusResult.StatusCode);
        }
        [Test]
        public void ShouldNotDeleteSportCenter_BadInformation()
        {
            int sportCenterId =-1;
            _sportCenterRepositoryMock.Setup(s => s.DeleteSportCenterById(sportCenterId)).Throws(new Exception());
           var sportCenterController = new SportCenterController(_sportCenterRepositoryMock.Object, _mapper.Object);
            var result = sportCenterController.DeleteSportCenterById(sportCenterId);
            var statusResult = result as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(404,statusResult.StatusCode);
        }
        [Test]
        public void ShouldNotDeleteSportCenter_MissingInformation()
        {
            int sportCenterId = 1;
            _sportCenterRepositoryMock.Setup(s => s.DeleteSportCenterById(sportCenterId)).Throws(new Exception());
            var sportCenterController = new SportCenterController(_sportCenterRepositoryMock.Object, _mapper.Object);
            var result = sportCenterController.DeleteSportCenterById(sportCenterId);
            var statusResult = result as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(404, statusResult.StatusCode);
        }
          public void ShouldUpdateSportCenter_HappyFlow()
        {
            var sportCentersDTO = new List<SportCenterDTO>()
            {
                new SportCenterDTO{Id=1,Name="Revo Gym",Address=1 }
            };

            var sportCenters = new List<SportCenter>()
            {
                new SportCenter{Id=1,Name="Revo Gym",Address=1 }
            };

            var sportCenterForUpdate = new SportCenterDTO { Id = 1, Name = "San Gym", Address = 2 };

            var sportCenterId = sportCenterForUpdate.Id;

            _sportCenterRepositoryMock.Setup(sc => sc.EditSportCenter(sportCenterId, It.IsAny<SportCenterDTO>()));
            _sportCenterRepositoryMock.Setup(sc => sc.GetSportCenterById(It.IsAny<int>())).Returns<SportCenter>(x => sportCenters.Find(sc => sc.Id == x.Id));

            var sportCenterController = new SportCenterController(_sportCenterRepositoryMock.Object, _mapper.Object);

            var result = sportCenterController.UpdateSportCenter(sportCenterId, sportCenterForUpdate);

            var okResult = result as StatusCodeResult;

            Assert.IsNotNull(okResult);

            Assert.AreEqual(200, okResult.StatusCode);

        }
        [Test]
        public void ShouldNotUpdateSportCenter_MissingData()
        {
            var sportCentersDTO = new List<SportCenterDTO>()
            {
                new SportCenterDTO{Id=1,Name="Revo Gym",Address=1 }
            };

            var sportCenters = new List<SportCenter>()
            {
                new SportCenter{Id=1,Name="Revo Gym",Address=1 }
            };

            var sportCenterForUpdate = new SportCenterDTO { Name = "San Gym", Address = 3 };

            var sportCenterId = sportCenterForUpdate.Id;

            _sportCenterRepositoryMock.Setup(sc => sc.EditSportCenter(sportCenterId, It.IsAny<SportCenterDTO>())).Throws(new Exception());
            _sportCenterRepositoryMock.Setup(sc => sc.GetSportCenterById(It.IsAny<int>())).Returns<SportCenter>(x => sportCenters.Find(sc => sc.Id == x.Id));

            var sportCenterController = new SportCenterController(_sportCenterRepositoryMock.Object, _mapper.Object);

            var result = sportCenterController.UpdateSportCenter(sportCenterId, sportCenterForUpdate);

            var badResult = result as StatusCodeResult;

            Assert.IsNotNull(badResult);

            Assert.AreEqual(404, badResult.StatusCode);

        }
        [Test]
        public void ShouldNotUpdateSportCenter_BadData()
        {
            var sportCentersDTO = new List<SportCenterDTO>()
            {
                new SportCenterDTO{Id=1,Name="Revo Gym",Address=1 }
            };

            var sportCenters = new List<SportCenter>()
            {
                new SportCenter{Id=1,Name="Revo Gym",Address=1 }
            };

            var sportCenterForUpdate = new SportCenterDTO { Id = 200, Name = "San Gym", Address = 3 };

            var sportCenterId = sportCenterForUpdate.Id;

            _sportCenterRepositoryMock.Setup(sc => sc.EditSportCenter(sportCenterId, It.IsAny<SportCenterDTO>())).Throws(new Exception());
            _sportCenterRepositoryMock.Setup(sc => sc.GetSportCenterById(It.IsAny<int>())).Returns<SportCenter>(x => sportCenters.Find(sc => sc.Id == x.Id));

            var sportCenterController = new SportCenterController(_sportCenterRepositoryMock.Object, _mapper.Object);

            var result = sportCenterController.UpdateSportCenter(sportCenterId, sportCenterForUpdate);

            var badResult = result as StatusCodeResult;

            Assert.IsNotNull(badResult);

            Assert.AreEqual(404, badResult.StatusCode);

        }
    }
}