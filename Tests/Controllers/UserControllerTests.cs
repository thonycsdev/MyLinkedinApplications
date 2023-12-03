// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net;
// using System.Threading.Tasks;
// using Api.Controllers;
// using AutoFixture;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
// using Service.DTOs;
// using Service.DTOs.Responses;
// using Service.Interfaces;
// using Xunit;

// namespace Tests.Controllers
// {
//     public class UserControllerTests
//     {
//         private readonly Fixture _fixture;
//         private readonly Mock<IUserService> _userServiceMock;
//         public UserControllerTests()
//         {
//             _userServiceMock = new Mock<IUserService>();
//             _fixture = new Fixture();
//         }
//         [Theory]
//         [InlineData("Anthony", null)]
//         [InlineData(null, "Email")]

//         public async void GivenAInvalidUserNameAndEmail_WhenTheRequestIsMade_ShouldThrowAArgumentExceptionWithACustomMessage(string name, string email)
//         {
//             var userController = new UserController(_userServiceMock.Object);
//             var userRequest = _fixture.Create<UserRequest>();
//             userRequest.Name = name;
//             userRequest.Email = email;
//             var exception = await userController.Create(userRequest);
//             Assert.Equal(expected: "Internal Server Error", actual: exception.ToString());
//         }

//         [Fact]
//         public async Task GivenAValidUserInformationInTheRequest_WhenTheRequestIsMade_ShouldReturnStatus200()
//         {
//             var userController = new UserController(_userServiceMock.Object);
//             var userRequest = _fixture.Create<UserRequest>();

//             var result = await userController.Create(userRequest);

//             Assert.IsType<OkResult>(result);
//         }

//         // [Fact]
//         // public async Task GetValues_ReturnsOkResult_WithValues()
//         // {
//         //     var userController = new UserController(_userServiceMock.Object);
//         //     var expectedValues = _fixture.CreateMany<UserResponse>();
//         //     _userServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(expectedValues);

//         //     var result = await userController.GetValues();

//         //     Assert.IsType<OkObjectResult>(result);
//         //     var okResult = Assert.IsType<OkObjectResult>(result);
//         //     var actualValues = Assert.IsType<List<UserResponse>>(okResult.Value);
//         // }

//     }
// }


// // [Fact]
// //         public async Task GetValues_ReturnsOkResult_WithValues()
// //         {
// //             // Arrange
// //             var userServiceMock = new Mock<IUserService>();
// //             var expectedValues = new List<string> { "value1", "value2" };
// //             userServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(expectedValues);
// //             var controller = new UserController(userServiceMock.Object);

// //             // Act
// //             var result = await controller.GetValues();

// //             // Assert
// //             var okResult = Assert.IsType<OkObjectResult>(result);
// //             var actualValues = Assert.IsType<List<string>>(okResult.Value);
// //             Assert.Equal(expectedValues, actualValues);
// //         }