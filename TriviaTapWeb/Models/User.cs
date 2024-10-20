using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaTapWeb.Models
{
    [Table("tb_user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string username { get; set; }
        public string password { get; set; }

        public bool isAdmin { get; set; }
    }
}
