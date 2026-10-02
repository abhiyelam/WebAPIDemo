using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Model
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Role { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation Properties
        public List<Projects>? Projects { get; set; }

        public List<TaskItem>? Tasks { get; set; }
    }
}
