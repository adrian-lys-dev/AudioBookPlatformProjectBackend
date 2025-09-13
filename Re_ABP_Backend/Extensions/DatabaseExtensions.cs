using Microsoft.EntityFrameworkCore;
using Re_ABP_Backend.Data.DB;

namespace Re_ABP_Backend.Extensions
{
    public static class DatabaseExtensions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}