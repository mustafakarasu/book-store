using System.Collections.Generic;
using System.Linq;
using BookStoreWebApi.Common;
using BookStoreWebApi.DbOperations;

namespace BookStoreWebApi.BookOperations.GetBooks
{
    public class GetBooksCommand
    {
        private readonly BookStoreDbContext _context;
        public GetBooksCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.OrderBy(x => x.Id);
            List<BooksViewModel> vm = new List<BooksViewModel>();

            foreach (var item in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = item.Title,
                    Genre = ((GenreEnum)item.GenreId).ToString(),
                    PageCount = item.PageCount,
                    PublishDate = item.PublishDate.Date.ToString("dd/MM/yyyy")
                });
            }

            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}