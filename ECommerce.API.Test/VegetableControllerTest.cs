using AutoMapper;
using ECommerce.API.Controllers;
using ECommerce.API.Interfaces;
using ECommerce.API.Models;
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
        private readonly IMapper _mapper;
        private readonly VegetableController _controller;

        public VegetableControllerTest()
        {
            _vegetableRepositoryMock = new Mock<IVegetableRepository>();
            _controller = new VegetableController(_vegetableRepositoryMock.Object, _mapper);
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
                Name = "Something",
                MFGDate = new DateTime(2012, 12, 25, 10, 30, 50),
                EXPDate = new DateTime(2012, 12, 25, 10, 30, 50),
                Price = 12000,
                Stock = 0,
                IsDeleted = false,
                Images = new List<DTOs.ImageDTO>(),
            };
            // Act
            var createdResponse =await _controller.Post(testVegetable);
            // Assert
            Assert.IsType < VegetableDTO>(createdResponse);

        }
    }
}
