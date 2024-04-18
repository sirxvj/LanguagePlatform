using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Entities;

public class Language:IEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Lesson>? Lessons { get; set; }
}