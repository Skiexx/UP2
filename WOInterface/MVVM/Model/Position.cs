using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WOInterface.MVVM.Model;

[Table("Positions")]
public class Position
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey(nameof(Order))]public int OrderId { get; set; }
    [ForeignKey(nameof(Dish))]public int DishId { get; set; }
    [Required] public int Count { get; set; }
    [ForeignKey(nameof(StatusPosition))] public int StatusId { get; set; }

    [InverseProperty("Positions")] public Order? Order { get; set; }
    [InverseProperty("Positions")] public Dish? Dish { get; set; }
    [InverseProperty("Positions")] public StatusPosition Status { get; set; }
}