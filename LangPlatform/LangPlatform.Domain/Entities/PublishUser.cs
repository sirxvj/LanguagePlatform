using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class PublishUser
{
    [Key] 
    public Guid Id { get; set; }

    [MaxLength(200)]
    public string Greeting { get; set; } = null!;

    public bool Visible { get; set; } = false;
    
    [ForeignKey("User")]
    public Guid UserId { get; set; }

    [ForeignKey("Language")] 
    public Guid LanguageId { get; set; }

    [ForeignKey("Category")] 
    public Guid CategoryId { get; set; }

    public Language? Language { get; set; }
    public Category? Category { get; set; }
    public User? User { get; set; }
}