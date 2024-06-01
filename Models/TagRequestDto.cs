﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TagRequestDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string? Color { get; set; }
    }
}
