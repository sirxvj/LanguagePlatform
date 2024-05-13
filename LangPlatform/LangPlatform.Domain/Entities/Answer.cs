using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using Domain.Interfaces;

namespace Domain.Entities;

public class Answer:IEntity
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(300)]
    public string AnswerBody { get; set; } = null!;

    public bool Accuracy { get; set; }

    [ForeignKey("Question")]
    public Guid QuestionId { get; set; }

    public virtual Question? Question { get; set; }
}