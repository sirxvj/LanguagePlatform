using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using Domain.Interfaces;

namespace Domain.Entities;

public class AnswerItem:IEntity
{
    [Key]
    public Guid Id { get; set; }

    public string Answer { get; set; } = null!;

    public bool Accuracy { get; set; }

    [ForeignKey("QuestionItem")]
    public Guid QuestionItemId { get; set; }

    public QuestionItem? QuestionItem { get; set; }
}