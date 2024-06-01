using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data
{
    public class Schedule
    {
        public int Id { get; set; }
        public UserTask Task { get; set; } = null!;
        public int TaskId { get; set; }
        [Required]
        public DateTime PlannedStartDate { get; set; }
        [Required]
        public DateTime PlannedEndDate { get; set; }
    }
}
