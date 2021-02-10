using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_ASP.Models
{
    [Table("locataires")]
    public class Locataire
    {
        // [Column("ID")]      //ces 3 sont obligatoire
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto increment
        public int idLocataire { get; set; }


        [Required(ErrorMessage = "Numéro de permisest obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Numéro de permis")]
        public int Npermis { get; set; }

        /* [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
         [Display(Name = "Nom complet")]
         public string nomComplet { get; set; }
 */

        /*        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
                [Display(Name = "téléphone")]
                public string tel { get; set; }*/

        /*  [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
          [Display(Name = "Adresse")]
          public string adresse { get; set; }*/

        /*        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
                [Display(Name = "Email")]
                [EmailAddress]
                public string email { get; set; }*/

        public ICollection<Reservation> reservations { get; set; }

        //public virtual ICollection<Voiture> Voitures; 



        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}