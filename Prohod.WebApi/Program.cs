using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using Prohod.WebApi.Accounts.Configuration;
using Prohod.WebApi.Configuration;
using Prohod.WebApi.Errors;
using Prohod.WebApi.Forms;
using Prohod.WebApi.Users;
using Prohod.WebApi.VisitRequests.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "cors",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});
var cert = new X509Certificate2("../CA.pem");
var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
store.Open(OpenFlags.ReadWrite);
store.Add(cert);
store.Close();

builder.Services
    .AddSwagger()
    .AddAccountsServices()
    .AddPostgresDbContext(builder.Configuration)
    .AddOperationErrorVisitor()
    .AddVisitRequestsServices()
    .AddUsersServices()
    .AddFormsServices();

var app = builder.Build();

app.UseCors("cors");
app.UseHsts();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();