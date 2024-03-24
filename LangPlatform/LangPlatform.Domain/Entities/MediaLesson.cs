using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public class MediaLesson:IEntity
{
    [Key]
    public Guid Id { get; set; }
    
    [ForeignKey("Lesson")]
    public Guid LessonId { get; set; }
    public byte[]? Bytes { get; set; }
    public string? FileType { get; set; }
    public string? FileName { get; set; }
   

    public Lesson? Lesson { get; set; }
}