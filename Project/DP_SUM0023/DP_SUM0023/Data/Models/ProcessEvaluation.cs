using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DP_SUM0023.Data.Models
{
    [Table("processevaluation")]
    public class ProcessEvaluation
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public DateTime DatePerformed { get; set; }

        [Required]
        public virtual Process Process { get; set; }

        [Required]
        public virtual UserAccount EvaluatorAccount { get; set; }
    }
}
