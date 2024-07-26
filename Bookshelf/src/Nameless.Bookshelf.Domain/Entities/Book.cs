using Nameless.Bookshelf.Domain.Common;

namespace Nameless.Bookshelf.Domain.Entities {
    public sealed class Book : EntityBase<string> {
        public required string Title { get; set; }
        public string? Overview { get; set; }
        public DateOnly? PublishDate { get; set; }
        public double? Rating { get; set; }
    }
}
