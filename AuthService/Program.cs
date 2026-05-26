using AuthService.Application.Interfaces;
using AuthService.Application.Services;
using AuthService.Infrastructure.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// JWT config
builder.Services.AddSingleton<IJwtTokenService , JwtTokenService>();
builder.Services.AddSingleton<IAuthorizationService , AuthorizationService>();
// UserService HTTP client
builder.Services.AddHttpClient<UserServiceClient>(c =>
{
    c.BaseAddress = new Uri("http://localhost:5253/"); // your UserService URL
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
