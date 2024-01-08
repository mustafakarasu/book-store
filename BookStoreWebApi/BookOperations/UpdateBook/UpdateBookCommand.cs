using BookStoreWebApi.BookOperations.CreateBook;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _context;

        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(int id, UpdateBookModel model)
        {
            var book = _context.Books.AsNoTracking().SingleOrDefault(x => x.Id == id);

            if ( book is not null )
                throw new InvalidOperationException($"{id} değerine sahip bir kitap yok.");

            var updatedBook = new Book();
            updatedBook.Id = id;
            updatedBook.Title = model.Title;
            updatedBook.GenreId = model.GenreId;
            updatedBook.PageCount = model.PageCount;
            updatedBook.PublishDate = model.PublishDate;

            _context.Books.Update(updatedBook);
            _context.SaveChanges();
        }
    }
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
