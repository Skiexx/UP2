using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WOInterface.Annotations;
using WOInterface.Core;

namespace WOInterface.MVVM.Model;

[Table("OrderStatuses")]
public class StatusOrder : BaseViewModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [NotMapped] private string _statusName;
    [Required] [MaxLength(255)] public string? StatusName
    {
        get => _statusName;
        set
        {
            _statusName = value;
            OnPropertyChanged();
        }
    }

    [NotMapped] private ICollection<Order> _orders;
    [InverseProperty("Status")]
    public ICollection<Order>? Orders
    {
        get => _orders;
        set
        {
            _orders = value;
            OnPropertyChanged();
        }
    }
}