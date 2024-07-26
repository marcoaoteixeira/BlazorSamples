using FluentValidation;

namespace Nameless.Bookshelf.Application.Books.Commands.CreateBook {
    public sealed class CreateBookCommandValidator : AbstractValidator<CreateBookCommand> {
        public CreateBookCommandValidator() {
            RuleFor(book => book.Title)
                .NotEmpty();

            RuleFor(book => book.Rating)
                .GreaterThanOrEqualTo(0D)
                .When(book => book.Rating is not null);
        }
    }
}
