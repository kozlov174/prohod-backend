using System.Reflection;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using Npgsql;
using Prohod.Domain.ErrorsBase;
using Prohod.Domain.RepositoriesBase;
using Prohod.Domain.VisitRequests;
using Prohod.Domain.VisitRequests.Forms;
using Prohod.Infrastructure.Database;
using Prohod.Infrastructure.Users.Authentication;
using Prohod.Infrastructure.Users.Authentication.JwtTokens;
using Prohod.Infrastructure.Users.Authentication.Options;
using Prohod.Infrastructure.Users.Authentication.Options.Configuration;
using Prohod.Infrastructure.Users.Authentication.Passwords;
using Prohod.Infrastructure.Users.Authentication.Passwords.Options;
using Prohod.Infrastructure.Users.Authentication.Passwords.Options.Configuration;
using Prohod.Infrastructure.VisitRequests;
using Prohod.WebApi.Configuration;
using Prohod.WebApi.Errors;
using Prohod.WebApi.Users.Authentication.Configuration;
using Prohod.WebApi.Users.Models.AutoMapperProfiles;
using Prohod.WebApi.VisitRequests.Models.AutoMapperProfiles;

var builder = WebApplication.CreateBuilder(args);
IdentityModelEventSource.ShowPII = true;

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddAuthorization();
builder.Services.AddOptions<PasswordsSalt>();
builder.Services.AddOptions<AuthenticationOptions>();
builder.Services.ConfigureOptions<ConfigureAuthenticationOptions>();
builder.Services.ConfigureOptions<ConfigureJwtBearerOptions>();
builder.Services.ConfigureOptions<ConfigurePasswordsSaltOptions>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddDbContext<PostgresDbContext>(options =>
    {
        options.UseNpgsql(
            new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString(ConnectionStringsNames.PostgreSql)) {IncludeErrorDetail = true}.ConnectionString);
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    })
    .AddScoped<IAppDbContext, PostgresDbContext>();
builder.Services.AddAutoMapper(
    configuration => configuration
            .AddProfiles(new Profile[]
            {
                new FormAggregationDtoProfile(),
                new FormDtoProfile(),
                new UserDtoProfile(),
                new VisitRequestAggregatedProfile()
            }));

builder.Services.AddScoped<IJwtTokensGenerator, JwtTokensGenerator>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IPasswordsHashCalculator, Sha256PasswordsHashCalculator>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IOperationErrorVisitor<ActionResult>, OperationErrorVisitor>();
builder.Services.AddScoped<IVisitRequestsRepository, VisitRequestsRepository>();

builder.Services.AddScoped<IVisitRequestsService, VisitRequestsService>();

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