using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using PatoShopping.API.Model.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(cfg =>
{
    cfg.SwaggerDoc("v1", new() { Title = "PatoShopping.API", Version = "v1" }); 
});

builder.Services.AddDbContext<DbContextApp>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));





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
