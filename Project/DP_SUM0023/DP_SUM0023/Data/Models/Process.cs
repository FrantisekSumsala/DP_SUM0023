using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DP_SUM0023.Data.Models
{
    [Table("process")]
    public class Process
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual Project Project { get; set; }

        public virtual List<ProcessEvaluation> Evaluations { get; set; } = new List<ProcessEvaluation>();
        public virtual List<ProcessReport> Reports { get; set; } = new List<ProcessReport>();
    }
}
