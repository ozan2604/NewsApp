using Application.Repositories.AiLogRepository;
using Application.Repositories.AppRoleRepository;
using Application.Repositories.AppUserRepository;
using Application.Repositories.CategoryRepository;
using Application.Repositories.NewsRepository;
using Application.Repositories.TagRepository;
using Application.Services;
using Application.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.Context;
using Persistence.Repositories.AiLogRepository;
using Persistence.Repositories.AppRoleRepository;
using Persistence.Repositories.AppUserRepository;
using Persistence.Repositories.CategoryRepository;
using Persistence.Repositories.NewsRepository;
using Persistence.Repositories.TagRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<NewsAppDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<NewsAppDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = JwtTokenDefault.ValidAudience,
                    ValidIssuer = JwtTokenDefault.ValidIssuer,

                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key)),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddScoped<IReadNewsRepository, ReadNewsRepository>();
            services.AddScoped<IWriteNewsRepository, WriteNewsRepository>();

            services.AddScoped<IReadCateagoryRepository, CategoryReadRepository>();
            services.AddScoped<IWriteCategoryRepository, CategoryWriteRepository>();

            services.AddScoped<IReadTagRepository, ReadTagRepository>();
            services.AddScoped<IWriteTagRepository, WriteTagRepository>();

            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppRoleRepository, AppRoleRepository>();

            services.AddHttpClient<IAIService, OpenRouterAiRepository>();
            services.AddScoped<IAiLogRepository, AiLogRepository>();




        }
    }
}
