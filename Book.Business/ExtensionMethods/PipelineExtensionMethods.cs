﻿using GoSolve.Dummy.Book.Business.MappingProfiles;
using GoSolve.Dummy.Book.Business.Services;
using GoSolve.Dummy.Book.Business.Services.Interfaces;
using GoSolve.Dummy.Book.Data.ExtensionMethods;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoSolve.Dummy.Book.Business.ExtensionMethods;

public static class PipelineExtensionMethods
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DtoMappingProfile));

        services.AddDataLayer(configuration);

        services.AddTransient<IBookService, BookService>();

        return services;
    }
}
