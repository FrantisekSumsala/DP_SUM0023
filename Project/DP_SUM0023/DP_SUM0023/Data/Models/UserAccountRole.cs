using System.ComponentModel.DataAnnotations;

namespace DP_SUM0023.Data.Models
{
    public class UserAccountRole
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
