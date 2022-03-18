using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WOInterface.Core;

namespace WOInterface.MVVM.Model;

[Table("Orders")]
public class Order : BaseViewModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public DateTime CreationDateTime { get; set; }
    [ForeignKey(nameof(User))] public int UserId { get; set; }
    [NotMapped] private int _statusId;

    [ForeignKey(nameof(Status))]
    public int StatusId
    {
        get => _statusId;
        set
        {
            _statusId = value;
            OnPropertyChanged();
        }
    }

    [InverseProperty("Order")] public ICollection<Position>? Positions { get; set; }
    [InverseProperty("Orders")] public User? User { get; set; }
    [NotMapped] private StatusOrder _status;

    [InverseProperty("Orders")]
    public StatusOrder Status
    {
        get => _status;
        set
        {
            _status = value;
            OnPropertyChanged();
        }
    }
}