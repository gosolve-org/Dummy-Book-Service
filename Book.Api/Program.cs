using GoSolve.Dummy.Book.Api.Business.MappingProfiles;
using GoSolve.Dummy.Book.Api.Business.Services;
using GoSolve.Dummy.Book.Api.Business.Services.Interfaces;
using GoSolve.HttpClients.Dummy.Review;
using GoSolve.Tools.Api.ExtensionMethods;
using GoSolve.Tools.Common.HttpClients;

var builder = WebApplication.CreateBuilder(args);

// builder.Host.UseSerilog();
builder.Services.AddAutoMapper(typeof(DtoMappingProfile));

builder.Services.AddTransient<IBookService, BookService>();

builder.Services.AddInternalHttpClient<IReviewHttpClient, ReviewHttpClient>(builder.Configuration, "review");
builder.Services.AddApiTools();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiTools();

app.Run();
