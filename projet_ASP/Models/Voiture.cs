using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projet_ASP.Models
{

    public class Voiture
    {
        [Column("ID")]      //ces 3 sont obligatoire
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "matricule")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public string matricule { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "marque")]
        public string marque { get; set; }
 
        
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "modèl")]
        public string model { get; set; }
        
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "couleur")]
        public string couleur { get; set; } 
        
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "coutParJour")]
        public Decimal coutParJour { get; set; }
        
       // [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "km")]
        public Decimal km { get; set; }

        [ForeignKey("Proprietaire")]
        public int idProprietaire { get; set; }
        public Proprietaire proprietaire  { get; set; }
 
    }
}
/* + Matricule
+ marque :string
+ annee :int
+ modèl: int
+ marque :DateTime
+ couleur
+ etat
+ km
+ CoutParJour
*/