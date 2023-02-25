using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DP_SUM0023.Data.Models
{
    [Table("report")]
    public class Report
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public virtual Project Project { get; set; }

        [Required]
        public virtual UserAccount Creator { get; set; }
    }
}
