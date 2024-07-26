using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using Nameless.Bookshelf.Application.Books.Queries.ListBooks;
using Nameless.Bookshelf.Contracts.Books;

namespace Nameless.Bookshelf.Web.Components.Pages.Books {
    public partial class List {
        [Inject]
        public IMediator Mediator { get; set; } = null!;

        public PaginationState PaginationState { get; set; } = new() {
            ItemsPerPage = 10
        };

        private async ValueTask<GridItemsProviderResult<BookDto>> BookGridItemsProvider(GridItemsProviderRequest<BookDto> request) {
            var pagination = await Mediator.Send(new ListBooksQuery {
                Page = request.StartIndex + 1,
                Size = request.Count
            });

            return GridItemsProviderResult.From(pagination.Items, pagination.Count);
        }
    }
}
