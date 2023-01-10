using CleanMovie.API;
using Microsoft.EntityFrameworkCore;
using CleanMovie.Infrastructure;
using CleanMovie.Application; //а че с дефолтными юзингами ?

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        b=>b.MigrationsAssembly("CleanMovie.API")));
builder.Services.AddScoped<IMovieService, MovieService>(); 
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

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