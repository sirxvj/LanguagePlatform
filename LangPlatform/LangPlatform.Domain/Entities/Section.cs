using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public class Section:IEntity
{
    [Key]
    public Guid Id { get; set; }

    public int Order { get; set; }

    [MaxLength(200)]
    public string? Title { get; set; }

    public string? RawText { get; set; }

    [ForeignKey("Media")] 
    public Guid? MediaId { get; set; }


    
    public virtual Media? Media { get; set; }
    
    [ForeignKey("Article")]
    public Guid ArticleId { get; set; }
    
    public virtual Article? Article { get; set; }
}