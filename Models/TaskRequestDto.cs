using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TaskRequestDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public short Priority { get; set; }
        [Required]
        public short Status { get; set; }
        [Required]
        public DateTime PlannedStartDate { get; set; }
        [Required]
        public DateTime PlannedEndDate { get; set; }
        public IEnumerable<int> Tags { get; set; } = null!;

    }
}
