using Nameless.Bookshelf.Application.Common.Persistence;
using Nameless.Bookshelf.Domain.Entities;
using Nameless.Bookshelf.Infrastructure.Common.Persistence;

namespace Nameless.Bookshelf.Infrastructure.Books.Persistence {
    public sealed class BookRepository : IBookRepository {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookRepository(ApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateAsync(Book book, CancellationToken cancellationToken) {
            await _applicationDbContext.Books.AddAsync(book, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<Book> Query()
            => _applicationDbContext.Books;
    }
}
