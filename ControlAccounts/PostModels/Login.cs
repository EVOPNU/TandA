﻿using System.ComponentModel.DataAnnotations;

namespace ControlAccounts.PostModels
{
    public class Login
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }     

        public string Name { get; set; }


        
    }
}
