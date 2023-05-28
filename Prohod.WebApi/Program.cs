using System.Text.Json.Serialization;
using Prohod.WebApi.Configuration;
using Prohod.WebApi.Users.Authentication.Configuration;
using Prohod.WebApi.VisitRequests.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddSwagger();
builder.Services.AddAuthenticationServices();
builder.Services.AddPostgresDbContext(builder.Configuration);
builder.Services.AddAutoMapperWithProfiles();
builder.Services.AddGenericRepository();
builder.Services.AddOperationErrorVisitor();
builder.Services.AddVisitRequestsServices();

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