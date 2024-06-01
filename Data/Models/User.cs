using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = string.Empty;

        public ICollection<UserTask> Tasks { get; set; }
    }
}
