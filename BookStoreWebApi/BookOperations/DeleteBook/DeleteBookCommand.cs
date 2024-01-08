using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;
using System;
using System.Linq;

namespace BookStoreWebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;
        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if ( book is not null )
                throw new InvalidOperationException($"{id} değerine sahip bir kitap yok.");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
