using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VifTech.Business.Repositories.Implementations;
using VifTech.Business.Repositories.Interfaces;
using VifTech.Business.Services.Implementations;
using VifTech.Business.Services.Interfaces;
using VifTech.Domain.Contexts;
using VifTech.Helpers.Configuration;

namespace VifTech.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(ConfigurationKeys.ConnectionString ?? throw new ArgumentNullException("Connection String Invalid !"));
            });

            services.AddSingleton(new ConfigurationKeys(configuration));
            services.AddTransient<IQuotationService, QuotationService>();
            services.AddTransient<ISecurityService, SecurityService>();
            return services;
        }
        public static IServiceCollection RepositoriesConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IQuotationRepository, QuotationRepository>();
            return services;
        }
        public static IServiceCollection AuthConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = ConfigurationKeys.Issuer,
                    ValidAudience = ConfigurationKeys.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(ConfigurationKeys.SecretKey)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            return services;
        }
    }
}
