using AutoMapper;
using ECommerce.API.Controllers;
using ECommerce.API.DTOs;
using ECommerce.API.Interfaces;
using Moq;

namespace ECommerce.API.Test
{
    //public class ImageControllerTest
    //{
    //    private readonly Mock<IImageRepository> _imageRepositoryMock;
    //    private readonly IMapper _mapper;
    //    private readonly ImageController _controller;

    //    public ImageControllerTest()
    //    {
    //        _imageRepositoryMock = new Mock<IImageRepository>();
    //        _controller = new ImageController(_imageRepositoryMock.Object, _mapper);
    //    }

    //    [Fact]
    //    public async Task PostImage_WhenSuccess_ReturnOk()
    //    {
    //        Arrange
    //       ImageDTO testImage = new ImageDTO()
    //       {
    //           Id = 0,
    //           VegetableId = 1,
    //           ImageURL = "Something",
    //           IsDeleted = false,
    //       };
    //        Act
    //       var createdResponse = await _controller.Post(testImage);
    //        Assert
    //        Assert.IsType<ImageDTO>(createdResponse);

    //    }
    //}
}