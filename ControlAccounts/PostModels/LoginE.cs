using System.ComponentModel.DataAnnotations;

namespace ControlAccounts.PostModels
{
    public class LoginE
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string NewEmail { get; set; }


        
    }
}
