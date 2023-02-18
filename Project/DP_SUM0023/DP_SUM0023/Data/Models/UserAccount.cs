using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DP_SUM0023.Data.Models
{
    [Table("useraccount")]
    public class UserAccount
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public virtual UserAccountRole Role { get; set; }

        public virtual List<Project> AssignedProjects { get; set; } = new List<Project>();
    }
}
