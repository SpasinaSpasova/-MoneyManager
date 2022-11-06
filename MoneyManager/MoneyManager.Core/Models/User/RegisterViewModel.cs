using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MoneyManager.Infrastructure.Data.DataConstants.ApplicationUser;

namespace MoneyManager.Core.Models.User
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(ApplicationUserUserNameMaxLength, MinimumLength = ApplicationUserUserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(ApplicationUserFirstNameMaxLength, MinimumLength = ApplicationUserFirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(ApplicationUserLastNameMaxLength, MinimumLength = ApplicationUserLastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(ApplicationUserPasswordMaxLength, MinimumLength = ApplicationUserPasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(ApplicationUserPasswordMaxLength, MinimumLength = ApplicationUserPasswordMinLength)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(ApplicationUserEmailMaxLength, MinimumLength = ApplicationUserEmailMinLength)]
        public string Email { get; set; } = null!;
    }
}
