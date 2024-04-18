using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Entities;

public class User:IEntity
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(50)]
    public string Username { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    [MaxLength(50)]
    public string Email { get; set; } = null!;
    
    public RoleType Role { get; set; }
    
    public virtual ICollection<Lesson>? Lessons { get; set; }
}

public enum RoleType
{
    Admin,
    Readonly
}