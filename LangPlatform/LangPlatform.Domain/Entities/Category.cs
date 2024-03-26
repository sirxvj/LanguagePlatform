using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Entities;

public class Category:IEntity
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public ICollection<Lesson>? Lessons { get; set; }
}