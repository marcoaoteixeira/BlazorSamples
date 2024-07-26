using MediatR;
using Microsoft.AspNetCore.Components;
using Nameless.Bookshelf.Application.Books.Commands.CreateBook;
using Nameless.Bookshelf.Application.Books.Queries.GetBookByID;
using Nameless.Bookshelf.Contracts.Books;

namespace Nameless.Bookshelf.Web.Components.Pages.Books {
    public partial class Form {
        [Inject]
        public IMediator Mediator { get; set; } = null!;

        [SupplyParameterFromQuery]
        public string? ID { get; set; }

        [SupplyParameterFromForm(FormName = "BookForm")]
        private BookDto Model { get; set; } = new();

        protected override async Task OnInitializedAsync() {
            if (!string.IsNullOrWhiteSpace(ID)) {
                Model = await Mediator.Send(new GetBookByIDQuery { ID = ID }) ?? new BookDto();
            }

            await base.OnInitializedAsync();
        }

        private async Task HandleFormSubmitAsync() {
            var response = await Mediator.Send(new CreateBookCommand(Title: Model.Title ?? string.Empty,
                                                                     Overview: Model.Overview,
                                                                     PublishDate: Model.PublishDate,
                                                                     Rating: Model.Rating));

            
        }
    }
}
