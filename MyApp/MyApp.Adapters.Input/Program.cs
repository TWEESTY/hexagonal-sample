using MyApp.Adapters.Input.AutoMapper;
using MyApp.Adapters.Output.Context;
using MyApp.Adapters.Output.Extensions;
using MyApp.Adapters.Output.Repositories;
using MyApp.Application.Application.Services;
using MyApp.Application.Extensions;
using MyApp.Application.Ports.Input.BookManagementService;
using MyApp.Application.Ports.Output.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAdaptersOutput();
builder.Services.AddApplication();

// C'est de la responsabilité de qui ?
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddAutoMapper(typeof(BookProfile));

builder.Services.AddControllers();
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
