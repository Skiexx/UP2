using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WOInterface.MVVM.Model;

[Table("Roles")]
public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [MaxLength(255)] public string? RoleName { get; set; }

    [InverseProperty("Role")] public ICollection<User>? Users { get; set; }
}