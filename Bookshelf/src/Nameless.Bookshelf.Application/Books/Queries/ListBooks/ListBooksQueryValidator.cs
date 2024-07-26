using FluentValidation;

namespace Nameless.Bookshelf.Application.Books.Queries.ListBooks {
    public sealed class ListBooksQueryValidator : AbstractValidator<ListBooksQuery> {
        public ListBooksQueryValidator() {
            RuleFor(query => query.Page)
                .GreaterThanOrEqualTo(1)
                .When(query => query.Page is not null);

            RuleFor(query => query.Size)
                .GreaterThanOrEqualTo(1)
                .When(query => query.Size is not null);
        }
    }
}
