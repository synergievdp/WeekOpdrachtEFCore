using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core.Entities;

namespace WeekOpdrachtEFCore.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new { Id = 1, Email = "test1@example.com", Name = "Name1", Surname = "Surname1" },
                new { Id = 2, Email = "test2@example.com", Name = "Name2", Surname = "Surname2" }
            );
        }
    }
}
