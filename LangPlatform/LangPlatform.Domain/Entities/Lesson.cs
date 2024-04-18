using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public class Lesson:IEntity
{
    [Key]
    public Guid Id { get; set; }
    public bool Approved { get; set; }
    public DateTime CreatedAt { get; set; }
    public double Avg { get; set; }
    
    [ForeignKey("Language")] 
    public Guid LanguageId { get; set; }
    
    [ForeignKey("Category")] 
    public Guid CategoryId { get; set; }
    
    [ForeignKey("Creator")] 
    public Guid CreatorId { get; set; }

    
    public Language? Language { get; set; }
    public User? Creator { get; set; }
    public Test? Test { get; set; }
    public Article? Article { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public Category? Category { get; set; }
    public ICollection<MediaLesson>? Media { get; set; }
}