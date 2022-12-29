using GoSolve.Dummy.Book.Data.Repositories;
using GoSolve.Dummy.Book.Data.Repositories.Interfaces;
using GoSolve.Tools.Common.ExtensionMethods;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoSolve.Dummy.Book.Data.ExtensionMethods;

public static class PipelineExtensionMethods
{
    public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseTools<BookDbContext>(configuration);

        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<IBookGenreRepository, BookGenreRepository>();

        return services;
    }
}
