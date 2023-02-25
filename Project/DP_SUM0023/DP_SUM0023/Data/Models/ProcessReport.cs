using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DP_SUM0023.Data.Models
{
    [Table("processreport")]
    public class ProcessReport
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public virtual Process Process { get; set; }

        [Required]
        public virtual UserAccount Creator { get; set; }
    }
}
