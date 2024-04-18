using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public class Lesson:IEntity
{
    [Key]
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;
    public bool Approved { get; set; }
    public DateTime CreatedAt { get; set; }
    public double Avg { get; set; }
    
    [ForeignKey("Language")] 
    public Guid LanguageId { get; set; }
    
    [ForeignKey("Category")] 
    public Guid CategoryId { get; set; }
    
    [ForeignKey("Creator")] 
    public Guid CreatorId { get; set; }
    
    
    [ForeignKey("Media")] 
    public Guid? MediaId { get; set; }

    
    public virtual Language? Language { get; set; }
    public virtual User? Creator { get; set; }
    public virtual Test? Test { get; set; }
    public virtual Article? Article { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; }
    public virtual Category? Category { get; set; }
    public virtual Media? Media { get; set; }
}