using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Prohod.Infrastructure.Users.Authentication.JwtTokens;
using Prohod.Infrastructure.Users.Authentication.Options.Configuration;
using Prohod.Infrastructure.Users.Authentication.Passwords;
using Prohod.Infrastructure.Users.Authentication.Passwords.Options;
using Prohod.Infrastructure.Users.Authentication.Passwords.Options.Configuration;
using AuthenticationOptions = Prohod.Infrastructure.Users.Authentication.Options.AuthenticationOptions;

namespace Prohod.WebApi.Users.Authentication.Configuration;

public static class AuthenticationRegistrar
{
    public static IServiceCollection AddAuthenticationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddOptions<PasswordsSalt>();
        serviceCollection.AddOptions<AuthenticationOptions>();
        serviceCollection.ConfigureOptions<ConfigureAuthenticationOptions>();
        serviceCollection.ConfigureOptions<ConfigurePasswordsSaltOptions>();
        serviceCollection.ConfigureOptions<ConfigureJwtBearerOptions>();
        serviceCollection
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
        
        return serviceCollection
            .AddScoped<IJwtTokensGenerator, JwtTokensGenerator>()
            .AddScoped<IAuthenticationService, AuthenticationService>()
            .AddScoped<IPasswordsHashCalculator, Sha256PasswordsHashCalculator>();
    }
}