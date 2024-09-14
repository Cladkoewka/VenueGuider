using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using VenueGuider.API.Middlewares;
using VenueGuider.Application.Services;
using VenueGuider.Domain.Interfaces;
using VenueGuider.Infrastructure.DbContext;
using VenueGuider.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

services.AddScoped<ICategoryRepository, CategoryRepository>();
services.AddScoped<ITagRepository, TagRepository>();
services.AddScoped<IVenueRepository, VenueRepository>();

services.AddScoped<CategoryService>();
services.AddScoped<TagService>();
services.AddScoped<VenueService>();

services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = string.Empty;
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "VenueGuider API V1");
    });
}

app.MapControllers();

app.Run();