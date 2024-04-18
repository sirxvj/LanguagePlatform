using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public class Article:IEntity
{
    [Key] public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    [ForeignKey("Lesson")] 
    public Guid LessonId { get; set; }
    
    public Lesson? Lesson { get; set; }
    public ICollection<Section>? Sections { get; set; }
}