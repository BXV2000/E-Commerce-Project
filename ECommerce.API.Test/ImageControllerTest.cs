using AutoMapper;
using ECommerce.API.Controllers;
using ECommerce.API.Interfaces;
using Moq;

namespace ECommerce.API.Test
{
    public class ImageControllerTest
    {
        private readonly Mock<IImageRepository> _imageRepositoryMock;
        private readonly IMapper _mapper;
        private readonly ImageController _controller;

        public ImageControllerTest()
        {
            _imageRepositoryMock = new Mock<IImageRepository>();
            _controller = new ImageController(_imageRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task GetImage_WhenSuccess_ReturnOk()
        {
            var result = _controller.Get();
            Assert.NotNull(result);
        }
    }
}