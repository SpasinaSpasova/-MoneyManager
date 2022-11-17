using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.Models.User
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
