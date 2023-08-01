using Book.Core.Repositories;
using Book.Data.Context;
using Book.Data.Repositories.Implementations;
using Book.Service.Profiles.Categories;
using Book.Service.Services.Implementations;
using Book.Service.Services.Interfaces;
using Book.Service.Validations.Categories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<BookDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddCors(o => o.AddPolicy("P136", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddControllers().AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<CategoryPostDtoValidation>());

builder.Services.AddAutoMapper(typeof(CategoryProfile));


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBookService, BookService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("admin_v1", new OpenApiInfo
    {
        Version = "admin_v1",
        Title = "admin_v1",
        Description = "An API in dotnet core 6",

    });
    c.SwaggerDoc("client_v1", new OpenApiInfo
    {
        Version = "client_v1",
        Title = "client_v1",
        Description = "An API in dotnet core 6",

    });
});



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options=>
    {
        options.SwaggerEndpoint($"/swagger/admin_v1/swagger.json", "admin_v1");
        options.SwaggerEndpoint($"/swagger/client_v1/swagger.json", "client_v1");
    });
}


app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
