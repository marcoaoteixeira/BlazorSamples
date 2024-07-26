using MediatR;
using Nameless.Bookshelf.Contracts.Books;

namespace Nameless.Bookshelf.Application.Books.Commands.CreateBook {
    public record CreateBookCommand(
        string Title,
        string? Overview,
        DateOnly? PublishDate,
        double? Rating) : IRequest<BookDto>;
}
