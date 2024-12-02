using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IFakeDatabase, FakeDatabase>();

            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IRepository<Author>, Repository<Author>>();
            //        .AddScoped<IRepository<Book>, Repository<Book>>()
            //        .AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            //services.AddScoped<IRepository<Book>, Repository<Book>>();
            //services.AddScoped<IRepository<User>, Repository<User>>();

            return services;
        }
    }
}
