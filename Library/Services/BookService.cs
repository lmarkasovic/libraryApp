﻿using Library.Models;
using Library.Models.ViewModels;
using Library.Repository;

namespace Library.Services
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepo;
        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public IEnumerable<BookViewModel> GetBooks()
        {
            var books = _bookRepo.GetAllBooks();
            var result = new List<BookViewModel>();
            foreach (var b in books)
            {
                string nameSurname = null;
                if (b.BorrowerUserId != null)
                {
                    nameSurname = _bookRepo.GetBorrowerDetails(b.BorrowerUserId.Value);
                }
                BookViewModel book = new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    BorrowerUserId = b.BorrowerUserId,
                    BorrowerNameSurname = nameSurname
                };
                result.Add(book);
            }
            return result;
        }

        public void BorrowBook(string BookId, int userId)
        {
            var book = _bookRepo.GetBookById(BookId);
            book.BorrowerUserId = userId;          
            _bookRepo.SaveBook(book);
        }

        public void ReturnBook(string BookId, int userId)
        {
            var book = _bookRepo.GetBookById(BookId);
            book.BorrowerUserId = null;
            _bookRepo.SaveBook(book);
        }
    }
}