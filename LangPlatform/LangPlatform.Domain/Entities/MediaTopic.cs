using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public class MediaTopic:IEntity
{
    [Key]
    public Guid Id { get; set; }
    
    [ForeignKey("Section")]
    public Guid SectionId { get; set; }
    
    public byte[]? Bytes { get; set; }
    public string? FileType { get; set; }
    public string? FileName { get; set; }
   

    public Section? Section { get; set; }
}