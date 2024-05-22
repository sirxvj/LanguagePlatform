using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[PrimaryKey(nameof(UserId), nameof(User2Id))]
public class Friends
{
    [Column(Order = 0)]
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    
    [Column(Order = 1)]
    [ForeignKey("User2")]
    public Guid User2Id { get; set; }

    public virtual User? User { get; set; }
    public virtual User? User2 { get; set; }
}