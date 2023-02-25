using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DP_SUM0023.Data.Models
{
    [Table("evaluation")]
    public class Evaluation
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public DateTime DatePerformed { get; set; }

        [Required]
        public virtual Project Project { get; set; }

        [Required]
        public virtual UserAccount EvaluatorAccount { get; set; }
    }
}
