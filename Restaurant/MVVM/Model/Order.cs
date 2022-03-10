using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.MVVM.Model
{
    [Table("Orders")]
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] public DateTime CreationDateTime { get; set; }
        [ForeignKey(nameof(User))] public int UserId { get; set; }
        [ForeignKey(nameof(Place))] public int PlaceId { get; set; }  
        
        [InverseProperty("Orders")] public Place? Place { get; set; }
        [InverseProperty("Order")] public ICollection<Position>? Positions { get; set; }
        [InverseProperty("Orders")] public StatusOrder? Status { get; set; }
        [InverseProperty("Orders")] public User? User { get; set; }
        
    }
}