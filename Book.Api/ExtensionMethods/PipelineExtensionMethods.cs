using GoSolve.Dummy.Book.Api.MappingProfiles;
using GoSolve.Dummy.Book.Business.ExtensionMethods;
using GoSolve.HttpClients.Dummy.Review;
using GoSolve.Tools.Api.ExtensionMethods;
using GoSolve.Tools.Common.HttpClients;

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

        return app;
    }
}
