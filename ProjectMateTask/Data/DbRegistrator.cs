using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.DAL.Context;

namespace ProjectMateTask.Data;

internal static class DbRegistrator
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProjectMateTaskDb>(opt =>
        {
            var type = configuration["Type"];
            switch (type)
            {
                case "MSSQL":
                    opt.UseSqlServer(configuration.GetConnectionString(type));
                    break;
                case null: throw new InvalidOperationException("Не определён тип базы данных");
                default: throw new InvalidOperationException($"Тип {type} не поддерживается");
            }
        });

        services.AddTransient<DbInitializer>();
        
        return services;
    }
}