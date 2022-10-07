using MyApp.Adapters.Input.Extensions;
using MyApp.Adapters.Output.Extensions;
using MyApp.Adapters.Output.Repositories;
using MyApp.Application.Ports.Output.Repositories;

var builder = WebApplication.CreateBuilder(args);

// TODO : est-ce logique ? Je ne peux pas le mettre côté Application car pas de référence à l'adapter output...
builder.Services.AddTransient<IBookRepository, BookRepository>();

builder.Services.AddAdaptersInput();
builder.Services.AddAdaptersOutput();

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
