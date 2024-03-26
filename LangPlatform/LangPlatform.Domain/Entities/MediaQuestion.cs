using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public class MediaQuestion:IEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public byte[]? Bytes { get; set; }
    public string? FileType { get; set; }
    public string? FileName { get; set; }
   

    public QuestionItem? QuestionItem { get; set; }
}