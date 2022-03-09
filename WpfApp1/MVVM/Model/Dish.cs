using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace WpfApp1.Models
{
    [Table("Dishes")]
    public class Dish
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(255)] public string Name { get; set; }
        [Required, Column(TypeName = "decimal(10,2)")] public decimal Price { get; set; }
        [Required] public string CookingTime { get; set; }
        
        [InverseProperty("Dish")] public ICollection<Position> Positions { get; set; }
    }
}