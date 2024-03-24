using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public class Section:IEntity
{
    [Key]
    public Guid Id { get; set; }

    public int Order { get; set; }

    public string? Title { get; set; }

    public string? RawText { get; set; }

    [ForeignKey("MediaTopic")]
    public Guid MediaTopicId { get; set; }
    
    [ForeignKey("Article")]
    public Guid ArticleId { get; set; }


    public MediaTopic? MediaTopic { get; set; }
    public Article? Article { get; set; }
}