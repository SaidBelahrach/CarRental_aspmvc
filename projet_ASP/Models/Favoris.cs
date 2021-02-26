using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_ASP.Models
{
    public class Favoris
    {
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto increment
        public int idFavoris { get; set; }


        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<ApplicationUser> users { get; set; }
        public int idAdmin { get; set; }
        [ForeignKey("idAdmin")]
        public virtual Admin admin { get; set; }
    }
}