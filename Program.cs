using System;
using System.Collections.Generic;
using System.Linq;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder
            .AllowAnyOrigin() // Allow all origins
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// CORS middleware
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

namespace Demo
{
    class Program
    {
        private readonly ILogger<Program> logger;
        public Program(ILogger<Program> logger)
        {
            this.logger = logger;
        }
        static void Main()
        {
        }
    }
}
