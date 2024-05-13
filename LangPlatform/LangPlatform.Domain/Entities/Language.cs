using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Interfaces;

namespace Domain.Entities;

public class Language:IEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    
    [JsonIgnore]
    public virtual ICollection<Lesson>? Lessons { get; set; }
}