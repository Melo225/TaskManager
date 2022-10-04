using System;
using System.ComponentModel.DataAnnotations;
using TaskManagerAPI.IdentityAuth;

namespace TaskManagerAPI.Models
{
    public class Todo
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "")]
        public string Description { get; set; }

        public bool Status { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "CreatedOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; } = false;
    }
}

