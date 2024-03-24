using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public class Test:IEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    [ForeignKey("Lesson")] 
    public Guid LessonId { get; set; }

    public List<QuestionItem?> QuestionItems { get; set; }
    public Lesson? Lesson { get; set; }
}