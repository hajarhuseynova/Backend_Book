using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("admin_v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "admin_v1",
        Description = "An API in dotnet core 6",

    });
    c.SwaggerDoc("client_v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "client_v1",
        Description = "An API in dotnet core 6",

    });
});

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
