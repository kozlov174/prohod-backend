using Microsoft.AspNetCore.Mvc;
using Prohod.Domain.ErrorsBase;
using Prohod.WebApi.Errors;

namespace Prohod.WebApi.Configuration;

public static class OperationErrorVisitorRegistrar
{
    public static IServiceCollection AddOperationErrorVisitor(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IOperationErrorVisitor<ActionResult>, OperationErrorVisitor>();
    }
}