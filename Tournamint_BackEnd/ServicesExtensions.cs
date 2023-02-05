using Tournamint_BackEnd.Services;
using Tournamint_BackEnd.Repositories;

namespace Tournamint_BackEnd
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddTransient<IMatchAdapter, MatchAdapter>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserMatchRepository, UserMatchRepository>();

            return services;
        }
    }
}
