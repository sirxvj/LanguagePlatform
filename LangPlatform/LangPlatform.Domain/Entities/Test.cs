using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public class Test:IEntity
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(200)]
    public string Description { get; set; } = null!;
    
    [ForeignKey("Lesson")] 
    public Guid LessonId { get; set; }

    public virtual ICollection<Question> Questions { get; set; }
    public virtual Lesson? Lesson { get; set; }
}