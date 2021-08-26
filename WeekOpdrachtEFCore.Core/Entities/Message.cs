using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOpdrachtEFCore.Core.Entities
{
    public class Message : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public DateTime DateTimeSend { get; set; } = DateTime.Now;
    }
}
