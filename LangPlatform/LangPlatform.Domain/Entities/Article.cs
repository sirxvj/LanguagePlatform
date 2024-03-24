using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Entities;

public class Article:IEntity
{
    [Key] public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public ICollection<Section>? Sections { get; set; }
}