using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core.Entities;
using WeekOpdrachtEFCore.Core.Interfaces.Services;

namespace WeekOpdrachtEFCore.Data
{
    public static class DataHostExtensions
    {
        public static IHost InitializeData(this IHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try {
                    var context = services.GetRequiredService<DataContext>();
                    var users = services.GetRequiredService<IUserService>();
                    var messages = services.GetRequiredService<IMessageService>();

                    context.Database.Migrate();
                    SeedData(users, messages);
                } catch (Exception)
                {
                    throw;
                }
            }
            return host;
        }

        public static void SeedData(IUserService users, IMessageService messages) {
            SeedUsers(users);
            SeedMessages(users, messages);
        }

        public static void SeedUsers(IUserService users) {

            for (int i = 1; i < 3; i++)
            {
                var email = $"test{i}@example.com";
                if (users.GetByEmail(email) != null)
                {
                    users.Add(new User() { Name = $"Name{i}", Surname = $"Surname{i}", Email = email });
                }
            }
        }
        public static void SeedMessages(IUserService users, IMessageService messages) {
            for (int i = 1; i < 3; i++)
            {
                User user;
                if ((user = users.GetById(i)) != null)
                {
                    messages.Add(new Message() { Title = $"Title{i}", Content = $"Test{i}", Sender = user, SenderId = user.Id });
                }
            }

        }
    }
}
