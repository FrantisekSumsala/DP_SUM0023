using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DP_SUM0023.Data.Models
{
    [Table("useraccountrole")]
    public class UserAccountRole
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
