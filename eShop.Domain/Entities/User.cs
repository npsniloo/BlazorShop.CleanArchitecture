using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Domain.Entities;

public class User : IEntity<int>
{


    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(200)]
    public string PasswordSalt { get; set; } = null!;
    [StringLength(200)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(200)]
    public string FullName { get; set; } = null!;

    public bool IsAdmin { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RegisterDate { get; set; }

    public int? RecoveryCode { get; set; }
    private User()
    {
        // EF constructor
    }

    private User(string email, string fullName, string passwordHash, string passwordSalt, bool isAdmin, DateTime registerDate)
    {
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        FullName = fullName;
        IsAdmin = isAdmin;
        RegisterDate = registerDate;
    }

    public static User Create(
        string email,
        string fullName,
        string passwordHash,
        string passwordSalt,
        bool isAdmin)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.", nameof(email));

        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("FullName name is required.", nameof(fullName));

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password hash is required.", nameof(passwordHash));
        if (string.IsNullOrWhiteSpace(passwordSalt))
            throw new ArgumentException("Password salt is required.", nameof(passwordSalt));

        return new User(
            email.Trim().ToLowerInvariant(),
            fullName.Trim(),
            passwordHash,
            passwordSalt,
            isAdmin,
            DateTime.UtcNow);
    }
}
