﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Banking_System.ViewModels
{
    public class ContactVM
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Subject { get; set; }
        
        [Required]
        [MaxLength(250, ErrorMessage = "Too Long")]
        public string Message { get; set; }
    }
}
