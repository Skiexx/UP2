using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.MVVM.Model
{
    [Table("Users")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(255)] public string FirstName { get; set; }
        [Required, MaxLength(255)] public string LastName { get; set; }
        [MaxLength(255)] public string MiddleName { get; set; }
        [Required, MaxLength(255)] public string Login { get; set; }
        [Required, MaxLength(255)] public string Password { get; set; }
        [ForeignKey(nameof(Role))] public int RoleId { get; set; }
        
        [InverseProperty("User")] public ICollection<Order> Orders { get; set; }
        [InverseProperty("Users")] public Role Role { get; set; }
        [InverseProperty("User")] public ICollection<Shift> Shifts { get; set; }
    }
}