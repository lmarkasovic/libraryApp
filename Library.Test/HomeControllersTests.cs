using Library.Controllers;
using Library.Services;
using Moq;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Test
{
    public class HomeControllerFixture : IDisposable
    {
        public HomeController controller;
        public Mock<IBookService> mockBookService;
        public Mock<IUserService> mockUserService;

        public HomeControllerFixture()
        {
            mockBookService = new Mock<IBookService>();
            mockUserService = new Mock<IUserService>();

            mockBookService.Setup(service => service.GetBooks()).ReturnsAsync(TestData.GetTestCatalog());
            mockUserService.Setup(service => service.GetUserDetails(It.IsAny<int>())).ReturnsAsync(TestData.GetTestUsers());

        }

        public void Dispose()
        {

        }

    }

    public class HomeControllerTests : IClassFixture<HomeControllerFixture>
    {
        HomeControllerFixture _fixture;

        public HomeControllerTests(HomeControllerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetBooks_ReturnsAViewResult_WithAListOfBooks()
        {
            // Arrange
            _fixture.controller = new HomeController(_fixture.mockBookService.Object, _fixture.mockUserService.Object);

            // Act
            var result = await _fixture.controller.IndexAsync();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<BookViewModel>>(viewResult.Model);
            Assert.Equal(2, model.Count());
        }
    }
}