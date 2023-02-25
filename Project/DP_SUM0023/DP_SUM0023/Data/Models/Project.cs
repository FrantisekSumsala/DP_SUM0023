using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DP_SUM0023.Data.Models
{
    [Table("project")]
    public class Project
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual Company Company { get; set; }

        public virtual List<UserAccount> AssignedTo { get; set; } = new List<UserAccount>();

        public virtual List<Process> Processes { get; set; } = new List<Process>();

        public override bool Equals(object? obj)
        {
            if (obj == null) 
                return false;

            Project other = obj as Project;
            if (other == null) 
                return false;

            return Id == other.Id;
        }
    }
}
