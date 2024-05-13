using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Domain.Interfaces;

namespace Domain.Entities;

public class Review:IEntity
{
    [Key]
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
    [MaxLength(200)]
    public string Title { get; set; } = null!;
    [MaxLength(1000)]
    public string Body { get; set; } = null!;

    [Range(0,5)]
    public int Rate { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }

    public virtual User? User { get; set; }
     [ForeignKey("Lesson")]
     public Guid LessonId { get; set; }

     public virtual Lesson? Lesson { get; set; }
}