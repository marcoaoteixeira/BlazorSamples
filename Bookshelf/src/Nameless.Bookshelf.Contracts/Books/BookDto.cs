using System.ComponentModel.DataAnnotations;

namespace Nameless.Bookshelf.Contracts.Books {
    public record BookDto {
        public string? ID { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Overview { get; set; }

        public DateOnly? PublishDate { get; set; }

        [Range(0D, double.MaxValue)]
        public double? Rating { get; set; }
    }
}
