using AutoMapper;
using DotnetBootcampProject.API.Controllers;
using DotnetBootcampProject.Core.DTOs;
using DotnetBootcampProject.Core.Models;
using DotnetBootcampProject.Core.Services;
using DotnetBootcampProject.Service.Mapping;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Test.Controllers
{
    public class PublisherControllerTests
    {
        private static IMapper _mapper;
        public PublisherControllerTests()
        {
            if(_mapper == null )
            {
                var mappingConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MapProfile());
                });
                //fake mapping:
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        private List<Publisher> GetTestObjects()
        {
            List<Publisher> publishers = new List<Publisher>()
            {
                new Publisher()
                {
                    Id=1,
                    PublisherName="test1",
                    City="test_city",
                    ContactEmail="test_email@test.com",
                    CreatedDate=DateTime.Now
                },
                new Publisher()
                {
                    Id=2,
                    PublisherName="test2",
                    City="test_city2",
                    ContactEmail="test_email2@test.com",
                    CreatedDate=DateTime.Now
                }
            };
            return publishers;
        }
        private Publisher GetPublisher()
        {
            Publisher publisher = new Publisher()
            {
                Id = 10,
                PublisherName="test10",
                City ="test_city10",
                ContactEmail=  "test@test.com",
                CreatedDate= DateTime.Now
            };
            return publisher;
        }
        [Fact]
        public async Task All_WhenCalled_ReturnPublishers()
        {
            //Arrange:
            var mock = new Mock<IPublisherService>();
            mock.Setup(m=>m.GetAllAsync()).ReturnsAsync(GetTestObjects());

            var publisherController = new PublisherController(_mapper,mock.Object);

            //Act:
            var result =await publisherController.All();
     
            //Assert:
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetById_WhenCalled_ReturnPublisher(int id)
        {
            var mock = new Mock<IPublisherService>();
            var expectedPublisher = new Publisher()
            {
                Id = id,
                PublisherName = "test1",
                City = "test_city",
                ContactEmail = "testmail@test.com",
                CreatedDate = DateTime.Now
            };
            mock.Setup(m=>m.GetById(id)).ReturnsAsync(expectedPublisher);

            var publisherController = new PublisherController(_mapper,mock.Object);

            //Act:
            var result = await publisherController.GetById(id);

            //assert:
            Assert.NotNull(result);
            // Assert

            var objectResult = (ObjectResult)result;
            Assert.Equal(200, objectResult.StatusCode);
        }
        [Fact]
        public async Task Save_WhenCalled_AddPublisher()
        {
            //Arrange:
            var mock = new Mock<IPublisherService>();
            var expectedPublisher = GetPublisher();
            mock.Setup(m=>m.AddAsync(expectedPublisher)).ReturnsAsync(expectedPublisher);

            var publisherController = new PublisherController(_mapper,mock.Object);

            //Act:
            var result = await publisherController.Save(_mapper.Map<PublisherDto>(expectedPublisher));

            //Assert:
            Assert.NotNull(result);
            var objectResult = (ObjectResult)result;
            Assert.Equal(201,objectResult.StatusCode);
        }
    }
}
