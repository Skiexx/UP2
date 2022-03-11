using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.MVVM.Model
{
    [Table("Positions")]
    public class Position
    {
        public int OrderId { get; set; }
        public int DishId { get; set; }
        [Required] public int Count { get; set; }
        
        [InverseProperty("Positions")] public Order? Order { get; set; }
        [InverseProperty("Positions")] public Dish? Dish { get; set; }
    }
}