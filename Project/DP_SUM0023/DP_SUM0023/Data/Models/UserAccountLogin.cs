using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DP_SUM0023.Data.Models
{
    [Table("useraccountlogin")]
    public class UserAccountLogin
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string PasswordSalt { get; set; }

        [Required]
        public virtual UserAccount Account { get; set; }

    }
}
