using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public class QuestionItem:IEntity
{
    [Key]
    public Guid Id { get; set; }
    [MaxLength(200)]
    public string Title { get; set; } = null!;
    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    [ForeignKey("Test")] 
    public Guid TestId { get; set; }
    
    [ForeignKey("Media")] 
    public Guid? MediaId { get; set; }
    
    public virtual Media? Media { get; set; }
    public virtual Test? Test { get; set; }
    public virtual ICollection<AnswerItem>? Answers { get; set; }
}