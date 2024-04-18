using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public class Article:IEntity
{
    [Key] public Guid Id { get; set; }

    [ForeignKey("Lesson")] 
    public Guid LessonId { get; set; }
    
    public virtual Lesson? Lesson { get; set; }
    public virtual ICollection<Section>? Sections { get; set; }
}