using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace sat_dal
{
    public static class DalServiceExtensions
    {
        public static IServiceCollection AddSatDal(this IServiceCollection services)
        {
            services.AddAutoMapper();

            return services;
        }
    }
}
