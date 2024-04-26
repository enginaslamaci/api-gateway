using IdentityServer;
using IdentityServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddLocalApiAuthentication();
builder.Services.AddIdentityServer()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApis())
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.GetClients())
                .AddTestUsers(Config.TestUsers)
                //.AddAspNetIdentity<ApplicationUser>();
                .AddDeveloperSigningCredential()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();


var app = builder.Build();

app.UseRouting();
app.UseIdentityServer();
//app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Welcome to IdentityServer !");

app.Run();
