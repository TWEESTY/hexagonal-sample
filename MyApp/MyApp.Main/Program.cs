using MyApp.Adapters.Input.Extensions;
using MyApp.Adapters.Output.Extensions;
using MyApp.Adapters.Output.Repositories;
using MyApp.Application.Extensions;
using MyApp.Application.Ports.Output.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAdaptersInput();
builder.Services.AddAdaptersOutput();
builder.Services.AddApplication();
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
