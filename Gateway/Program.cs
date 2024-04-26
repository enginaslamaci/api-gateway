using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToLower()}.json");

builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var authenticationScheme = "IdentityAuthenticationScheme";
builder.Services.AddAuthentication()
                .AddJwtBearer(authenticationScheme, options =>
                 {
                     options.Authority = builder.Configuration["IdentityServerURL"];
                     options.Audience = "resource_gateway";
                     options.RequireHttpsMetadata = false;
                 });

builder.Services.AddOcelot().AddCacheManager(options => options.WithDictionaryHandle());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.UseOcelot();

app.Run();
