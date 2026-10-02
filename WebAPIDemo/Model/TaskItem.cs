
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIDemo.Model
{
    [Table("Tasks")]
    public class TaskItem
    {
        [Key]
        [ScaffoldColumn(false)]
        public int TaskId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
   

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int AssignedTo { get; set; }

     

        [Required]
        [StringLength(20)]
        public string? Priority { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string? Status { get; set; } = string.Empty;

        //[Required]
        //public DateTime StartDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }= DateTime.Now;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation Properties (Optional)
        [ForeignKey("ProjectId")]
        public Projects? Project { get; set; }

        [ForeignKey("AssignedTo")]
        public Users? User { get; set; }

    }
}
