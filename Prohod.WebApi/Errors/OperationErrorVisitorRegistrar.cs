using Microsoft.AspNetCore.Mvc;
using Prohod.Domain.ErrorsBase;

namespace Prohod.WebApi.Errors;

public static class OperationErrorVisitorRegistrar
{
    public static IServiceCollection AddOperationErrorVisitor(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IOperationErrorVisitor<ActionResult>, OperationErrorVisitor>();
    }
}