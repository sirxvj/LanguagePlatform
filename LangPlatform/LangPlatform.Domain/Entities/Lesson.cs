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
    public double AverageRate { get; set; }
    
    [ForeignKey("Language")] 
    public Guid LanguageId { get; set; }
    
    [ForeignKey("Creator")] 
    public Guid CreatorId { get; set; }

    
    public Language? Language { get; set; }
    public User? Creator { get; set; }
    public Test? Test { get; set; }
    
    public ICollection<Review>? Reviews { get; set; }
    public ICollection<Category>? Category { get; set; }
    public ICollection<MediaLesson>? Medias { get; set; }
}