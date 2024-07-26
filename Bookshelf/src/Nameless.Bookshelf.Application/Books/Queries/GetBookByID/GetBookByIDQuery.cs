using MediatR;
using Nameless.Bookshelf.Contracts.Books;

namespace Nameless.Bookshelf.Application.Books.Queries.GetBookByID {
    public record GetBookByIDQuery : IRequest<BookDto?> {
        public required string ID { get; init; }
    }
}
