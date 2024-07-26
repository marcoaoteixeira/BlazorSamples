using MediatR;
using Nameless.Bookshelf.Application.Common.Persistence;
using Nameless.Bookshelf.Contracts.Books;
using Nameless.Bookshelf.Contracts.Common;

namespace Nameless.Bookshelf.Application.Books.Queries.ListBooks {
    public sealed class ListBooksQueryHandler : IRequestHandler<ListBooksQuery, Pagination<BookDto>> {
        private readonly IBookRepository _bookRepository;

        public ListBooksQueryHandler(IBookRepository bookRepository) {
            _bookRepository = bookRepository;
        }

        public Task<Pagination<BookDto>> Handle(ListBooksQuery request, CancellationToken cancellationToken) {
            var page = request.Page ?? 1;
            var size = request.Size ?? 10;

            var count = _bookRepository.Query()
                                       .Count();

            var books = _bookRepository.Query()
                                       .Skip((page - 1) * size)
                                       .Take(size)
                                       .Select(book => book.ToDto())
                                       .ToArray();

            var pagination = new Pagination<BookDto>(books, count);

            return Task.FromResult(pagination);
        }
    }
}
