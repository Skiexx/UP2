using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WOInterface.MVVM.Model
{
    [Table("Places")]
    public class Place
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(255)] public string? Zone { get; set; }
        
        [InverseProperty("Place")] public ICollection<Order>? Orders { get; set; }
    }
}