using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SpaProjectManagement;

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

app.UseAuthorization();

app.MapControllers();

app.Run();