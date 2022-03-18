using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WOInterface.MVVM.Model;

[Table("PositionStatuses")]
public class StatusPosition
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [MaxLength(255)] public string? StatusName { get; set; }

    [InverseProperty("Status")] public ICollection<Position> Positions { get; set; }
}