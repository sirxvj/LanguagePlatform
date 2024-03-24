using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Entities;

public class User:IEntity
{
    [Key]
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public string Email { get; set; } = null!;
    
    public RoleType Role { get; set; }
    
    public ICollection<Lesson>? Lessons { get; set; }
}

public enum RoleType
{
    Admin,
    Readonly
}