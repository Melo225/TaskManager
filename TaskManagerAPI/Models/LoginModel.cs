using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class LoginModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "")]
        public string Email { get; set; }

        [Required(ErrorMessage = "")]
        public string Password { get; set; }
    }
}

