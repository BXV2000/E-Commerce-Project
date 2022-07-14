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
        private IMapper _mapper;

        public VegetableControllerTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new VegetableProfile());
            });
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public async Task GetVegetables_WhenSuccess_ReturnOk()
        {

            // Arrange
            var vegetables = new List<Vegetable>
            {
                new Vegetable{Id =1, Name = "Vegies 1", CategoryId = 1},
                new Vegetable{Id =2, Name = "Vegies 2", CategoryId = 3},
                new Vegetable{Id =3, Name = "Vegies 3", CategoryId = 2},
            };

            var returnVegetableDTOs = new List<VegetableDTO>
            {
                new VegetableDTO{Id =1, Name = "Vegies 1", CategoryId = 1},
                new VegetableDTO{Id =2, Name = "Vegies 2", CategoryId = 3},
                new VegetableDTO{Id =3, Name = "Vegies 3", CategoryId = 2},
            };

            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.GetAsync()).Returns(Task.FromResult(vegetables));

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<List<VegetableDTO>>(vegetables)).Returns(returnVegetableDTOs);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Get()) as OkObjectResult;

            // Assert
            Assert.NotNull(result);

            var data = result.Value as IEnumerable<VegetableDTO>;
            Assert.NotNull(data);
            Assert.Equal(returnVegetableDTOs, data);
        }

        [Fact]
        public async Task GetVegetables_WhenNoVegetables_ReturnNotFound()
        {

            // Arrange
            var vegetables = new List<Vegetable>
            {
                new Vegetable{Id =1, Name = "Vegies 1", CategoryId = 1},
                new Vegetable{Id =2, Name = "Vegies 2", CategoryId = 3},
                new Vegetable{Id =3, Name = "Vegies 3", CategoryId = 2},
            };

            var returnVegetableDTOs = new List<VegetableDTO>
            {
                new VegetableDTO{Id =1, Name = "Vegies 1", CategoryId = 1},
                new VegetableDTO{Id =2, Name = "Vegies 2", CategoryId = 3},
                new VegetableDTO{Id =3, Name = "Vegies 3", CategoryId = 2},
            };

            var expectedMessage = "Vegies Empty";
            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.GetAsync()).Returns(Task.FromResult(new List<Vegetable>()));

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<List<VegetableDTO>>(vegetables)).Returns(returnVegetableDTOs);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Get()) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMessage, result.Value.ToString());
        }

        [Fact]
        public async Task GetVegetables_WhenException_ReturnBadRequest()
        {

            // Arrange
            var vegetables = new List<Vegetable>
            {
                new Vegetable{Id =1, Name = "Vegies 1", CategoryId = 1},
                new Vegetable{Id =2, Name = "Vegies 2", CategoryId = 3},
                new Vegetable{Id =3, Name = "Vegies 3", CategoryId = 2},
            };

            var returnVegetableDTOs = new List<VegetableDTO>
            {
                new VegetableDTO{Id =1, Name = "Vegies 1", CategoryId = 1},
                new VegetableDTO{Id =2, Name = "Vegies 2", CategoryId = 3},
                new VegetableDTO{Id =3, Name = "Vegies 3", CategoryId = 2},
            };

            var expectedMessage = "Something went wrong";
            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.GetAsync()).Throws(new Exception());

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<List<VegetableDTO>>(vegetables)).Returns(returnVegetableDTOs);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Get()) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMessage, result.Value.ToString());
        }

        [Fact]
        public async Task GetVegetableById_WhenSuccess_ReturnOk()
        {

            // Arrange
            var vegetable = new Vegetable { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var returnVegetableDTO = new VegetableDTO { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            int id = 1;

            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.GetByIdAsync(id)).Returns(Task.FromResult(vegetable));

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<VegetableDTO>(vegetable)).Returns(returnVegetableDTO);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Get(id)) as OkObjectResult;

            // Assert
            Assert.NotNull(result);

            var data = result.Value as VegetableDTO;
            Assert.NotNull(data);
            Assert.Equal(returnVegetableDTO, data);
        }

        [Fact]
        public async Task GetVegetableById_WhenNoVegetable_ReturnNotFound()
        {

            // Arrange
            var vegetable = new Vegetable { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var returnVegetableDTO = new VegetableDTO { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            int id = 2;

            var expectedMessage = "Vegie not found :(";

            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.GetByIdAsync(id));

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<VegetableDTO>(vegetable)).Returns(returnVegetableDTO);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Get(id)) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMessage, result.Value.ToString());
        }

        [Fact]
        public async Task GetVegetableById_WhenException_ReturnBadRequest()
        {

            // Arrange
            var vegetable = new Vegetable { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var returnVegetableDTO = new VegetableDTO { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            int id = 2;

            var expectedMessage = "Something went wrong";

            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.GetByIdAsync(id)).Throws(new Exception());

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<VegetableDTO>(vegetable)).Returns(returnVegetableDTO);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Get(id)) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMessage, result.Value.ToString());
        }

        [Fact]
        public async Task PostVegetable_WhenSuccess_ReturnOk()
        {

            // Arrange
            var vegetable = new Vegetable { Id =1, Name = "Vegies 1", CategoryId = 1 };

            var returnVegetableDTO = new VegetableDTO { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.PostAsync(vegetable)).Returns(Task.FromResult(vegetable));

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<VegetableDTO>(vegetable)).Returns(returnVegetableDTO);
            mapperMock.Setup(s => s.Map<Vegetable>(returnVegetableDTO)).Returns(vegetable);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Post(returnVegetableDTO)) as OkObjectResult;

            // Assert
            Assert.NotNull(result);

            var data = result.Value as VegetableDTO;
            Assert.NotNull(data);
            Assert.Equal(returnVegetableDTO, data);
        }

        [Fact]
        public async Task PostVegetable_WhenException_ReturnBadRequest()
        {

            // Arrange
            var vegetable = new Vegetable { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var returnVegetableDTO = new VegetableDTO { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var expectedMessage = "Something went wrong";

            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.PostAsync(vegetable)).Throws(new Exception());

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<VegetableDTO>(vegetable)).Returns(returnVegetableDTO);
            mapperMock.Setup(s => s.Map<Vegetable>(returnVegetableDTO)).Returns(vegetable);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Post(returnVegetableDTO)) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMessage, result.Value.ToString());
        }

        [Fact]
        public async Task PutVegetable_WhenSuccess_ReturnOk()
        {

            // Arrange
            var vegetable = new Vegetable { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var returnVegetableDTO = new VegetableDTO { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var id = 1;

            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.PutAsync(id,vegetable)).Returns(Task.FromResult(vegetable));

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<VegetableDTO>(vegetable)).Returns(returnVegetableDTO);
            mapperMock.Setup(s => s.Map<Vegetable>(returnVegetableDTO)).Returns(vegetable);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Put(id,returnVegetableDTO)) as OkObjectResult;

            // Assert
            Assert.NotNull(result);

            var data = result.Value as VegetableDTO;
            Assert.NotNull(data);
            Assert.Equal(returnVegetableDTO, data);
        }

        [Fact]
        public async Task PutVegetable_WhenException_ReturnBadRequest()
        {

            // Arrange
            var vegetable = new Vegetable { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var returnVegetableDTO = new VegetableDTO { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var id = 1;

            var expectedMessage = "Something went wrong";

            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.PutAsync(id,vegetable)).Throws(new Exception());

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<VegetableDTO>(vegetable)).Returns(returnVegetableDTO);
            mapperMock.Setup(s => s.Map<Vegetable>(returnVegetableDTO)).Returns(vegetable);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Put(id,returnVegetableDTO)) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMessage, result.Value.ToString());
        }

        [Fact]
        public async Task DeleteVegetableById_WhenSuccess_ReturnOk()
        {

            // Arrange
            var vegetable = new Vegetable { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var returnVegetableDTO = new VegetableDTO { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            int id = 1;

            var expectedMessage = "Deleted";

            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.DeleteAsync(id));
            vegetableRepositoryMock.Setup(s => s.GetByIdAsync(id)).Returns(Task.FromResult(vegetable));

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<VegetableDTO>(vegetable)).Returns(returnVegetableDTO);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Delete(id)) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMessage, result.Value.ToString());
        }

        [Fact]
        public async Task DeleteVegetableById_WhenNoVegetable_ReturnNotFound()
        {

            // Arrange
            var vegetable = new Vegetable { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var returnVegetableDTO = new VegetableDTO { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            int id = 1;

            var expectedMessage = "Vegetable not found";

            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.DeleteAsync(id));
            vegetableRepositoryMock.Setup(s => s.GetByIdAsync(id));

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<VegetableDTO>(vegetable)).Returns(returnVegetableDTO);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Delete(id)) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMessage, result.Value.ToString());
        }

        [Fact]
        public async Task DeleteVegetableById_WhenException_ReturnBadRequest()
        {

            // Arrange
            var vegetable = new Vegetable { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            var returnVegetableDTO = new VegetableDTO { Id = 1, Name = "Vegies 1", CategoryId = 1 };

            int id = 1;

            var expectedMessage = "Something went wrong";

            var vegetableRepositoryMock = new Mock<IVegetableRepository>();
            vegetableRepositoryMock.Setup(s => s.DeleteAsync(id)).Throws(new Exception());
            vegetableRepositoryMock.Setup(s => s.GetByIdAsync(id)).Returns(Task.FromResult(vegetable));

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<VegetableDTO>(vegetable)).Returns(returnVegetableDTO);

            var controller = new VegetableController(vegetableRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.Delete(id)) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMessage, result.Value.ToString());
        }
    }
}
