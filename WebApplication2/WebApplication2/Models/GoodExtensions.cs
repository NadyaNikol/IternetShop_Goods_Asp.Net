using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WebApplication2.Repository;

namespace WebApplication2.Models
{
    public static class GoodExtensions
    {
        public static void AddGood(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Good>, GoodRepository>();
            services.AddTransient<UserRepository>();
        }

        public static void UseGood(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GoodMiddleware>();
        }
    }
}
