using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projet_ASP.Models
{
    public class Locataire
    {
        [Column("ID")]      //ces 3 sont obligatoire
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto increment
        public int idLocataire { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Nom complet")]
        public string nomComplet { get; set; }


        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "téléphone")]
        public string tel { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Adresse")]
        public string adresse { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string email { get; set; }

        public List<Voiture> Voitures; //un locataire peut louer plusieurs voitures
    }
}