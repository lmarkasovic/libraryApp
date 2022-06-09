using Library.Services;
using Moq;
using Library.Repository;

namespace Library.Test
{
    public class BookServiceFixture : IDisposable
    {
        public BookService service;
        public Mock<IBookRepository> mockBookRepository;
        public Mock<IUserRepository> mockUserRepository;

        public BookServiceFixture()
        {
            mockBookRepository = new Mock<IBookRepository>();
            mockUserRepository = new Mock<IUserRepository>();

            mockBookRepository.Setup(service => service.GetAllBooks()).ReturnsAsync(TestData.GetTestCatalog());
            mockBookRepository.Setup(service => service.GetBookById(It.IsAny<string>())).Returns(
                (string id) => 
                   Task.FromResult(TestData.GetTestCatalog().FirstOrDefault(x => x.Id == id))
                );
            mockUserRepository.Setup(service => service.GetUserDetails(It.IsAny<int>())).ReturnsAsync(TestData.GetTestUserDetails());
        }

        public void Dispose()
        {

        }

    }

    public class BookServiceTests : IClassFixture<BookServiceFixture>
    {
        BookServiceFixture _fixture;

        public BookServiceTests(BookServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetBooks_SetsBorrowedByCurrentUserPropertyTrue_IfUserHasBorrowedBooks()
        {
            // Arrange
            _fixture.service = new BookService(_fixture.mockBookRepository.Object, _fixture.mockUserRepository.Object);

            // Act
            var result = await _fixture.service.GetBooks(1);

            // Assert
            Assert.Equal(1, result.Count(r => r.BorrowedByCurrentUser == true));
        }

        [Fact]
        public async Task GetBooks_NoBorrowedByCurrentUserPropertyTrue_IfUserHasNoBorrowedBooks()
        {
            // Arrange
            _fixture.service = new BookService(_fixture.mockBookRepository.Object, _fixture.mockUserRepository.Object);

            // Act
            var result = await _fixture.service.GetBooks(5);

            // Assert
            Assert.Equal(0, result.Count(r => r.BorrowedByCurrentUser == true));
        }

        [Fact]
        public async Task BorrowBook_RaisesExceptionIfBookAlreadyBorrowed()
        {
            // Arrange
            _fixture.service = new BookService(_fixture.mockBookRepository.Object, _fixture.mockUserRepository.Object);

            Task act() => _fixture.service.BorrowBook("1", 5);

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(act);
        }

        [Fact]
        public async Task ReturnBook_RaisesExceptionIfBookNotBorrowedByCurrentUser()
        {
            // Arrange
            _fixture.service = new BookService(_fixture.mockBookRepository.Object, _fixture.mockUserRepository.Object);

            Task act() => _fixture.service.ReturnBook("1", 5);

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(act);
        }

    }
}