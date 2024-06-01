﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data
{
    public class TaskTag
    {
        public int TaskId { get; set; }
        public UserTask Task { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
