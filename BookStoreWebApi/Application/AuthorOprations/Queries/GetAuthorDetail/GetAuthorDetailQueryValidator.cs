using FluentValidation;

namespace BookStoreWebApi.Application.AuthorOprations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}