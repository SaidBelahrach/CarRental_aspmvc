using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_ASP.Models
{
    public class Notification
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idNotification { get; set; }

        public int idOroginalNotification { get; set; }

        public string type { get; set; }
        public string hint { get; set; }
        public bool vu { get; set; }
        public bool cliked { get; set; }

        public string ApplicationUserID { get; set; }

        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}