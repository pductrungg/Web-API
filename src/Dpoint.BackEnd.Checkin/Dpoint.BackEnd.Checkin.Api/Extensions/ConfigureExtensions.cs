using Dpoint.BackEnd.Checkin.Domain.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Dpoint.BackEnd.Checkin.Api.Extensions
{
    public static class ConfigureExtensions
    {

        public static void AddConfigureExtesions(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            var connectStr = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(connectStr));
        }
    }
}
