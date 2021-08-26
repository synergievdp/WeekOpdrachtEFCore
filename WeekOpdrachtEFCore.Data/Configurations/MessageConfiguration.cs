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
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasData(
                new Message() { Id = 1, Title = "Title1", Content = "Content1", SenderId = 1 },
                new Message() { Id = 2, Title = "Title2", Content = "Content2", SenderId = 2 }
            );
        }
    }
}
