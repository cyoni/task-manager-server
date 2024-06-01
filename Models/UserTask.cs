using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data
{
    public class UserTask
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        //public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; } 
        [Required]
        public short Priority { get; set; }
        [Required]
        public short Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [Required]
        public DateTime PlannedStartDate { get; set; }
        [Required]
        public DateTime PlannedEndDate { get; set; }
       
        public ICollection<TaskTag> TaskTags { get; set; }
        ///public ICollection<Tag> Tags { get; set; } = null!;


        //[ValidateNever]
        //  public User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public UserTask()
        {

            UpdatedAt = DateTime.Now;
        }
    }

}
