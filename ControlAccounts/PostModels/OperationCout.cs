using System.ComponentModel.DataAnnotations;

namespace ControlAccounts.PostModels
{
    public class OperationCout
    {
        [Required]
        public int id { get; set; }

        [Required]
        public int count { get; set; }

  
    }
}
