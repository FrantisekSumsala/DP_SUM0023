using System.ComponentModel.DataAnnotations;

namespace DP_SUM0023.Data.Models
{
    public class UserAccount
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public virtual UserAccountRole Role { get; set; }
    }
}
