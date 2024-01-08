using System;
using BookStoreWebApi.BookOperations.CreateBook;
using BookStoreWebApi.Common;
using FluentValidation;

namespace BookStoreWebApi.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookModel>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.PageCount).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Title).MinimumLength(2);
            RuleFor(x => x.PublishDate).Must(date => date <= DateTime.Now);
        }
    }
}
