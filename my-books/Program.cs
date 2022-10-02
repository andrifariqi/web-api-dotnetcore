using Microsoft.EntityFrameworkCore;
using my_books.Data;
using my_books.Data.Services;

var builder = WebApplication.CreateBuilder(args);
string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnectionStrings");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddTransient<BooksService>();

var app = builder.Build();

AppDbInitializer.Seed(app);

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
