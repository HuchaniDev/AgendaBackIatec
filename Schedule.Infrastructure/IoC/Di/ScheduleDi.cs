using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schedule.Application.Services;
using Schedule.Domain.Repositories;
using Schedule.Infrastructure.Database.EF.Context;
using Schedule.Infrastructure.Database.EF.Repositories;

namespace Schedule.Infrastructure.IoC.Di;

public static class ScheduleDi
{
    public static IServiceCollection RegisterDataBase(this IServiceCollection collection, IConfiguration configuration)
    {
        string connectionString = configuration["ConnectionStrings:localConnection"];
    
        collection.AddDbContext<ScheduleBdContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return collection;
    }
    
    public static IServiceCollection RegisterLibraries(this IServiceCollection collection)
    {
        collection.AddValidatorsFromAssembly(Assembly.Load("Academic.Application"));
        ValidatorOptions.Global.DisplayNameResolver = (type, memberInfo, expression) => memberInfo?.Name;
        return collection;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection collection)
    {
        collection.AddTransient<UserService>();

        return collection;
    }
    
    public static IServiceCollection RegisterRepositories(this IServiceCollection collection)
    {
        collection.AddTransient<IUserRepository, UserRepository>();
        return collection;
    }
}