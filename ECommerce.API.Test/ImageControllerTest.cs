using AutoMapper;
using ECommerce.API.Controllers;
using ECommerce.API.Data;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.API.Test
{
    public class ImageControllerTest
    {
        private static IMapper _mapper;
        [Fact]
        public void GetImage_WhenSuccess_ReturnOk()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Image>>();
            var mockContext = new Mock<ECommerceDbContext>();
            mockContext.SetupGet(x => x.Images).Returns(mockSet.Object);


            var controller = new ImageController(mockContext.Object,_mapper);

            //Act
            var result = controller.Get();


            //Assert
            Assert.NotNull(result);
        }
        public void GetImage_WhenError_ReturnErrorMessage()
        {
        }
    }
   
}
