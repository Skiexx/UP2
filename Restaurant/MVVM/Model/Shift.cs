using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.MVVM.Model
{
    [Table("Shifts")]
    public class Shift
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(User))] public int UserId { get; set; }
        [Required] public DateTime ShiftDateTime { get; set; } 
        
        [InverseProperty("Shifts")] public User? User { get; set; }
    }
}