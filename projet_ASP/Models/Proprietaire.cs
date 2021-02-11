using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_ASP.Models
{
    [Table("proprietaires")]
    public class Proprietaire
    {
        //[Column("ID")]      //ces 3 sont obligatoire
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID propriétaire")]
        public int idProprietaire { get; set; }

         
        [Required(ErrorMessageResourceType = typeof(projet_ASP.Resources.Models.Proprietaire), ErrorMessageResourceName = "type",AllowEmptyStrings =false)]
        [Display(Name = "type", ResourceType = typeof(projet_ASP.Resources.Models.Proprietaire))]
        public string type { get; set; } //agence ou particulier
        /*  [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
          [Display(Name = "Nom complet")]
          public string nomComplet { get; set; }*/


        /*       [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
               [Display(Name = "téléphone")]
               public string tel { get; set; }*/

        /*        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
                [Display(Name = "Adresse")]
                public string adresse { get; set; }
        */
        /*        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
                [Display(Name = "Email")]
                [EmailAddress]
                public string email { get; set; }
        */
        public ICollection<Voiture> Voitures { get; set; } //un proprietaire peut avoir plusieurs voitures
        public ICollection<Reclamation> Reclamations { get; set; } //un proprietaire peut avoir plusieurs voitures


        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}