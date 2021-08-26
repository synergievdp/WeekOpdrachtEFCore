using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core2.Interfaces.Services;
using WeekOpdrachtEFCore.Core2.Services;

namespace WeekOpdrachtEFCore.Core
{
    public static class CoreServiceExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
