using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatoShopping.API.Config;
using PatoShopping.API.Model;
using PatoShopping.API.Model.Context;
using PatoShopping.API.Repository;
using PatoShopping.API.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(cfg =>
{
    cfg.SwaggerDoc("v1", new() { Title = "PatoShopping.API", Version = "v1" });
});

//Configuração database
builder.Services.AddDbContext<DbContextApp>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// configuração AutoMapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();


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
