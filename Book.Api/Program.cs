using Serilog;
using GoSolve.Dummy.Book.Api.ExtensionMethods;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddApiLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiLayer();

app.Run();
