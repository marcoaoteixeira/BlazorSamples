using MediatR;
using Nameless.Bookshelf.Contracts.Books;
using Nameless.Bookshelf.Contracts.Common;

namespace Nameless.Bookshelf.Application.Books.Queries.ListBooks {
    public record ListBooksQuery : IRequest<Pagination<BookDto>> {
        public int? Page { get; init; }
        public int? Size { get; init; }
    }
}
