using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_business
{
    public static class BusinessExtensions
    {
        public static IServiceCollection AddSatBusiness(this IServiceCollection services)
        {
            services.AddAutoMapper();

            return services;
        }
    }
}
