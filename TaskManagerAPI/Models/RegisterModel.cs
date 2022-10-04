using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "")]
        public string Email { get; set; }

        [Required(ErrorMessage = "")]
        public string Password { get; set; }
    }
}

