using FluentValidation;
using MediatR;

namespace Nameless.Bookshelf.Application.Common.Behaviors {
    public sealed class ValidationPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> {
        private readonly IValidator<TRequest>? _validator;

        public ValidationPipelineBehavior(IValidator<TRequest>? validator) {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
            if (_validator is not null) {
                await _validator.ValidateAsync(instance: request,
                                               options: opts => opts.ThrowOnFailures(),
                                               cancellation: cancellationToken);
            }

            return await next();
        }
    }
}
