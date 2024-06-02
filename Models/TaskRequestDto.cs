using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TaskRequestDto : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Id < 0)
            {
                results.Add(new ValidationResult("Id can't be negative."));
            }

            if (PlannedStartDate > PlannedEndDate)
            {
                results.Add(new ValidationResult("Start date must be smaller than end date"));
            }

            return results;
        }
    }
}
