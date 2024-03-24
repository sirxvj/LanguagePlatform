using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Entities;

public class Topic:IEntity
{
    [Key]
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;
    public string Type { get; set; } = null!;
}