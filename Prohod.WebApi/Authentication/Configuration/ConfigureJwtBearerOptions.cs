using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Prohod.Infrastructure.Authentication.Options;

namespace Prohod.WebApi.Authentication.Configuration;

internal class ConfigureJwtBearerOptions : IConfigureOptions<JwtBearerOptions>
{
    private readonly IOptions<AuthenticationOptions> authenticationOptions;

    public ConfigureJwtBearerOptions(IOptions<AuthenticationOptions> authenticationOptions)
    {
        this.authenticationOptions = authenticationOptions;
    }

    public void Configure(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidIssuer = authenticationOptions.Value.Issuer,
            ValidAudience = authenticationOptions.Value.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(authenticationOptions.Value.SigningKey))
        };
    }
}