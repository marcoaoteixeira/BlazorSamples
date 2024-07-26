using MediatR;
using Nameless.Bookshelf.Application.Common.Persistence;
using Nameless.Bookshelf.Contracts.Books;

namespace Nameless.Bookshelf.Application.Books.Queries.GetBookByID {
    public sealed class GetBookByIDQueryHandler : IRequestHandler<GetBookByIDQuery, BookDto?> {
        private readonly IBookRepository _bookRepository;

        public GetBookByIDQueryHandler(IBookRepository bookRepository) {
            _bookRepository = bookRepository;
        }

        public Task<BookDto?> Handle(GetBookByIDQuery request, CancellationToken cancellationToken) {
            var book = _bookRepository.Query()
                                      .SingleOrDefault(book => book.ID == request.ID);

            return Task.FromResult(book?.ToDto());
        }
    }
}
