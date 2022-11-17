using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static MoneyManager.Infrastructure.Data.DataConstants.ApplicationUser;

namespace MoneyManager.Infrastructure.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(ApplicationUserFirstNameMaxLength)]
        public string FirstName { get; init; } = null!;

        [Required]
        [MaxLength(ApplicationUserLastNameMaxLength)]
        public string LastName { get; init; } = null!;

    }
}
