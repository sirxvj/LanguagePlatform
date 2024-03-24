using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.DTOs;
using Domain.Interfaces;

namespace Domain.Entities;

public class QuestionItem:IEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    [ForeignKey("Test")] 
    public Guid TestId { get; set; }
    
    public MediaQuestion? MediaQuestion { get; set; }
    public Test? Test { get; set; }
    public ICollection<AnswerItem>? Answers { get; set; }
}