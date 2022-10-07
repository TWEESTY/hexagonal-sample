using MyApp.Adapters.Input.AutoMapper;
using MyApp.Application.Application.Services;
using MyApp.Application.Ports.Input.BookManagementService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IBookManagementService, BookManagementService>();

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
