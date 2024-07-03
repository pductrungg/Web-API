using AutoMapper;
using Dpoint.BackEnd.Checkin.Domain.Contexts;
using Dpoint.BackEnd.Checkin.Domain.Entities;
using Dpoint.BackEnd.Checkin.Services.Interfaces;
using Dpoint.BackEnd.Checkin.Services.Models.Mappers;
using Dpoint.BackEnd.Checkin.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Dpoint.BackEnd.Checkin.Services
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region Service
            string issuer = configuration.GetValue<string>("TokenSettings:ClientId");
            string signingKey = configuration.GetValue<string>("TokenSettings:ClientSecret");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });


            services.AddTransient<ITodoService, TodoService>();
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            services.AddTransient<IUserCheckinService, UserCheckinService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ILeaveOfAbsenceService, LeaveOfAbsenceService>();
            // services.AddTransient<IPostOutOfOffice, CustomerMeetForm>();
            #endregion Services

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            return services;
        }
    }
}
