using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreWebApi.BookOperations.GetBooks;
using BookStoreWebApi.Common;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.BookOperations.GetBookById
{
    public class GetBookByIdCommand
    {
        private readonly BookStoreDbContext _context;
        public GetBookByIdCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public BookViewModel Handle(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if ( book is not null )
                throw new InvalidOperationException($"{id} değerine sahip bir kitap yok.");

            var bookVm = new BookViewModel()
            {
                Title = book.Title,
                Genre = ( (GenreEnum)book.GenreId ).ToString(),
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
            };

            return bookVm;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
