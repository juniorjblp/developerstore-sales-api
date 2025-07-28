using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.EventPublishing;
using Ambev.DeveloperEvaluation.ORM.EventPublishing;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();

        builder.Services.AddSingleton<EventPublisher>();
        builder.Services.AddSingleton<IEventPublisher>(sp => sp.GetRequiredService<EventPublisher>());
        builder.Services.AddHostedService(sp => sp.GetRequiredService<EventPublisher>());
    }
}