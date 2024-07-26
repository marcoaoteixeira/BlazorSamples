using Nameless.Bookshelf.Contracts.Books;
using Nameless.Bookshelf.Domain.Entities;

namespace Nameless.Bookshelf.Application.Books {
    public static class BookExtension {
        public static BookDto ToDto(this Book self)
            => new() {
                ID = self.ID,
                Title = self.Title,
                Overview = self.Overview,
                PublishDate = self.PublishDate,
                Rating = self.Rating
            };
    }
}
