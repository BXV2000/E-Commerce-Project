using AutoMapper;
using ECommerce.API.Controllers;
using ECommerce.API.DTOs;
using ECommerce.API.Interfaces;
using ECommerce.API.Models;
using ECommerce.API.Profiles;
using ECommerce.SharedDataModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.API.Test
{
    public class VegetableControllerTest
    {
        private readonly Mock<IVegetableRepository> _vegetableRepositoryMock;
        
        private readonly VegetableController _controller;

        public VegetableControllerTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new VegetableProfile()); //your automapperprofile 
            });
            var mapper = mockMapper.CreateMapper();

            _vegetableRepositoryMock = new Mock<IVegetableRepository>();
            _controller = new VegetableController(_vegetableRepositoryMock.Object, mapper);
        }

        [Fact]
        public async Task GetVegetable_WhenSuccess_ReturnOk()
        {
            var result = _controller.Get();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task PostVegetable_WhenSuccess_ReturnOk()
        {
            // Arrange
            VegetableDTO testVegetable = new VegetableDTO()
            {
                Id = 0,
                CategoryId = 1,
                Name = "string",
                Price = 0,
                Stock = 0,
                IsDeleted = false
            };
           

            // Act
            var createdResponse = await _controller.Post(testVegetable);
            // Assert
            Assert.IsType < OkObjectResult>(createdResponse as OkObjectResult);

        }
        
    }
}
