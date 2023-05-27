using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prohod.Domain.ErrorsBase;
using Prohod.Domain.Forms;
using Prohod.Domain.RepositoriesBase;
using Prohod.Infrastructure.Database;
using Prohod.Infrastructure.Users.Authentication;
using Prohod.Infrastructure.Users.Authentication.JwtTokens;
using Prohod.Infrastructure.Users.Authentication.Options;
using Prohod.Infrastructure.Users.Authentication.Options.Configuration;
using Prohod.Infrastructure.Users.Authentication.Passwords;
using Prohod.Infrastructure.Users.Authentication.Passwords.Options;
using Prohod.Infrastructure.Users.Authentication.Passwords.Options.Configuration;
using Prohod.WebApi.Configuration;
using Prohod.WebApi.Errors;
using Prohod.WebApi.Users.Authentication.Configuration;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IOperationErrorVisitor<ActionResult>, OperationErrorVisitor>();

builder.Services.AddOptions<PasswordsSalt>();
builder.Services.AddOptions<AuthenticationOptions>();
builder.Services.ConfigureOptions<ConfigureAuthenticationOptions>();
builder.Services.ConfigureOptions<ConfigureJwtBearerOptions>();
builder.Services.ConfigureOptions<ConfigurePasswordsSaltOptions>();

builder.Services.AddScoped<IFormsService, FormsService>();

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