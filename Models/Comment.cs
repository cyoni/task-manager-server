﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Text { get; set; } = string.Empty;
        public UserTask Task {  get; set; }
    }
}
