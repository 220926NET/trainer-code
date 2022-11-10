using DataAccess;
using Services;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<SqlConnectionFactory>(ctx => new SqlConnectionFactory(builder.Configuration.GetConnectionString("flashcardDB")));
builder.Services.AddDbContext<FlashcardsDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("flashcardDB")));
builder.Services.AddDbContext<FlashcardsCodeFirstDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("flashcardDB")));
builder.Services.AddScoped<IFlashCardStorage, FlashcardEFDbFirstRepo>();
builder.Services.AddScoped<FlashCardService>();
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
