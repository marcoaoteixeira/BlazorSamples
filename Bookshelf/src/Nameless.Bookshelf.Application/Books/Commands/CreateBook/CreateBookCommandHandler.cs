using MediatR;
using Microsoft.Extensions.Logging;
using Nameless.Bookshelf.Application.Common.Persistence;
using Nameless.Bookshelf.Contracts.Books;
using Nameless.Bookshelf.Domain.Entities;

namespace Nameless.Bookshelf.Application.Books.Commands.CreateBook {
    public sealed class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDto> {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<CreateBookCommandHandler> _logger;

        public CreateBookCommandHandler(IBookRepository bookRepository, ILogger<CreateBookCommandHandler> logger) {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken) {
            var book = new Book {
                ID = Guid.NewGuid().ToString(),
                Title = request.Title,
                Overview = request.Overview,
                PublishDate = request.PublishDate,
                Rating = request.Rating,
            };

            try {
                await _bookRepository.CreateAsync(book, cancellationToken);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error while creating a new book entry.");
                throw;
            }

            return book.ToDto();
        }
    }
}
