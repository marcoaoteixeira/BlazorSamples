using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Nameless.Bookshelf.Application.Common.Behaviors;

namespace Nameless.Bookshelf.Application {
    public static class ServiceCollectionExtension {
        private static readonly Assembly[] SupportAssemblies = [typeof(Root).Assembly];

        public static IServiceCollection RegisterApplicationLayer(this IServiceCollection self)
            => self.RegisterMediatR()
                   .RegisterValidators();

        private static IServiceCollection RegisterValidators(this IServiceCollection self)
            => self.AddValidatorsFromAssemblies(SupportAssemblies);

        private static IServiceCollection RegisterMediatR(this IServiceCollection self)
            => self.AddMediatR(configure => {
                configure.RegisterServicesFromAssemblies(SupportAssemblies);
                configure.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            });
    }
}
