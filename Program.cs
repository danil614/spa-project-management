using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SpaProjectManagement;
using SpaProjectManagement.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Получаем строку подключения из файла конфигурации
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));

// Add services to the container
builder.Services
    .AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions
        .ReferenceHandler = ReferenceHandler.Preserve);

// Authentication with JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = AuthOptions.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Автоматическая регистрация репозиториев
builder.Services.AddRepositories(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Регистрация логирующего middleware
app.UseLoggingMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();