using System;
using BookStoreWebApi.BookOperations.UpdateBook;
using FluentValidation;

namespace BookStoreWebApi.Validators
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookModel>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.PageCount).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Title).MinimumLength(2);
            RuleFor(x => x.PublishDate).Must(date => date <= DateTime.Now);
        }
    }
}