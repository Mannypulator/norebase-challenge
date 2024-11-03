using Microsoft.EntityFrameworkCore;
using NoreBaseApiChallenge.Application.interfaces;
using NoreBaseApiChallenge.Application.LikeArticle;
using NoreBaseApiChallenge.Domain.interfaces;
using NoreBaseApiChallenge.Infrastructure.Repository;

namespace NoreBaseApiChallenge;

public static class DependencyInjection
{
    public static void ConfigureRepositoryContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void ConfigureLikeServices(this IServiceCollection services)
    {
        services.AddScoped<ILikeService, LikeService>();
    }

    public static void ConfigureLikeRepository(this IServiceCollection services)
    {
        services.AddScoped<ILikeRepository, LikeRepository>();
    }
}
