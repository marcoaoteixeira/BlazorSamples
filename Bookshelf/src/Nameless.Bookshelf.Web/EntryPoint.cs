using Nameless.Bookshelf.Application;
using Nameless.Bookshelf.Infrastructure;
using Nameless.Bookshelf.Web.Components;

namespace Nameless.Bookshelf.Web {
    public class EntryPoint {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                   .AddRazorComponents()
                   .AddInteractiveServerComponents();

            builder
                .Services
                .RegisterApplicationLayer()
                .RegisterInfrastructureLayer();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
               .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
