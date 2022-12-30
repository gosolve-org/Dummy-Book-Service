using GoSolve.Clients.Dummy.Review.HttpClients;
using GoSolve.Clients.Dummy.Review.HttpClients.Interfaces;
using GoSolve.Dummy.Book.Api.MappingProfiles;
using GoSolve.Dummy.Book.Business.ExtensionMethods;
using GoSolve.Dummy.Book.Data;
using GoSolve.Dummy.Book.Data.Seeders.TestDataSeeders;
using GoSolve.Tools.Api.ExtensionMethods;
using GoSolve.Tools.Common.Helpers;
using GoSolve.Tools.Common.HttpClients;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace GoSolve.Dummy.Book.Api.ExtensionMethods;

public static class PipelineExtensionMethods
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DtoMappingProfile));

        services.AddInternalHttpClient<IReviewHttpClient, ReviewHttpClient>(configuration, "review");

        services.AddApiTools(configuration);
        services.AddBusinessLayer(configuration);

        return services;
    }

    public static WebApplication UseApiLayer(this WebApplication app)
    {
        app.UseApiTools();
        app.MigrateDatabase<BookDbContext>();

        if (EnvironmentHelper.IsDevelopment())
        {
            app.SeedTestData<BookDbContext>(builder =>
                builder.AddSeeder<BookTestDataSeeder>());
        }

        return app;
    }
}
