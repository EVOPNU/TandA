using System.ComponentModel.DataAnnotations;

namespace ControlAccounts.PostModels
{
    public class OperationCout
    {
        [Required]
        public int userid { get; set; }

        [Required]
        public int price { get; set; }

  
    }
}
