using System.ComponentModel.DataAnnotations;

namespace OnlineShopBlazor.Models.Dtos
{
    public class RegisterUserDto
    {
        [StringLength(50)]
        public string Email { get; set; } = null!;
        [StringLength(50)]
        public string Password { get; set; } = null!;

        [StringLength(200)]
        public string FullName { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}
