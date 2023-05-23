using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Prohod.Domain.ErrorsBase;
using Prohod.Domain.Users;
using Prohod.Infrastructure.Authentication;
using Prohod.Infrastructure.Authentication.JwtTokens;
using Prohod.Infrastructure.Authentication.Options;
using Prohod.Infrastructure.Authentication.Options.Configuration;
using Prohod.Infrastructure.Authentication.Passwords;
using Prohod.Infrastructure.Authentication.Passwords.Options;
using Prohod.Infrastructure.Authentication.Passwords.Options.Configuration;
using Prohod.Infrastructure.Database;
using Prohod.Infrastructure.Users;
using Prohod.WebApi.Authentication.Configuration;
using Prohod.WebApi.Configuration;
using Prohod.WebApi.Errors;

var builder = WebApplication.CreateBuilder(args);
IdentityModelEventSource.ShowPII = true;
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddDbContext<PostgresDbContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(
        builder.Configuration.GetConnectionString(ConnectionStringsNames.PostgreSql)))
    .AddScoped<IAppDbContext, PostgresDbContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IJwtTokensGenerator, JwtTokensGenerator>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IPasswordsHashCalculator, Sha256PasswordsHashCalculator>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IOperationErrorVisitor<ActionResult>, OperationErrorVisitor>();

builder.Services.AddOptions<PasswordsSalt>();
builder.Services.AddOptions<AuthenticationOptions>();
builder.Services.ConfigureOptions<ConfigureAuthenticationOptions>();
builder.Services.ConfigureOptions<ConfigureJwtBearerOptions>();
builder.Services.ConfigureOptions<ConfigurePasswordsSaltOptions>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();