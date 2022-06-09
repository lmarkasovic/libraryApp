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

            mockBookService.Setup(service => service.GetBooks(It.IsAny<int>())).ReturnsAsync(TestData.GetTestCatalogDTO());
            mockBookService.Setup(service => service.GetBookDetails(It.IsAny<string>())).ReturnsAsync(TestData.GetTestBookDetailsDTO());
            mockUserService.Setup(service => service.GetUserDetails(It.IsAny<int>())).ReturnsAsync(TestData.GetTestUsersDTO());

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
        public async Task Index_ReturnsAViewResult_WithAListOfBooks()
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

        [Fact]
        public async Task BorrowBook_ReturnsBadRequest_WhenArgInvalid()
        {
            // Arrange
            _fixture.controller = new HomeController(_fixture.mockBookService.Object, _fixture.mockUserService.Object);

            // Act
            var result = await _fixture.controller.BorrowBook(null, 1);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task ReturnBook_ReturnsBadRequest_WhenArgInvalid()
        {
            // Arrange
            _fixture.controller = new HomeController(_fixture.mockBookService.Object, _fixture.mockUserService.Object);

            // Act
            var result = await _fixture.controller.ReturnBook(null, 1);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetBookDetails_ReturnsBookDetails()
        {
            // Arrange
            _fixture.controller = new HomeController(_fixture.mockBookService.Object, _fixture.mockUserService.Object);

            // Act
            var result = await _fixture.controller.GetBookDetails("1");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<BookDetailsViewModel>(viewResult.Model);
            Assert.NotNull(model.Author);
        }
    }
}