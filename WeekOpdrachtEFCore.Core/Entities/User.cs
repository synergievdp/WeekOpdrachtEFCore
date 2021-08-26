﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOpdrachtEFCore.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
