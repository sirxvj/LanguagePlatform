using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Entities;

public class Media:IEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public byte[]? Bytes { get; set; }
    
    [MaxLength(10)]
    public string? FileType { get; set; } 
    
    [MaxLength(120)]
    public string? FileName { get; set; }


    public virtual Question? Question { get; set; }
    public virtual Section? Section { get; set; }
    public virtual Lesson? Lesson { get; set; }
}