using System.ComponentModel.DataAnnotations;

namespace Aspire.Vetpaws.Lab.Models
{
    public class LoginUserModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(4), MaxLength(20)]
        public string Password { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
