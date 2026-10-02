using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIDemo.Model
{
    public class Projects
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string? ProjectName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(20)]
        public string? Status { get; set; } = string.Empty;

        [Required]
        public int? CreatedBy { get; set; }

        // Navigation Properties
        [ForeignKey("CreatedBy")]
        public Users? User { get; set; }

        public List<TaskItem>? Tasks { get; set; }
    }
}
