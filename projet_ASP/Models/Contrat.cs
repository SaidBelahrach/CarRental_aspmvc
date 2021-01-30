using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projet_ASP.Models
{
   // [Table("contrats")]
    public class Contrat
    {
        [Column("ID")]      //ces 3 sont obligatoires
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int idContrat { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Date de location")]
        public DateTime dateLocation{ get; set; }  
        
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Date début")]
        public DateTime dateDebut { get; set; }  
        
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Date Fin")]
        public DateTime dateFin { get; set; }

        //+ dateCreation

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Type de paiement")]
        public string typeDePaiement { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Coût")]
        public Decimal cout { get; set; }


        public string matricule { get; set; }
        [ForeignKey("matricule")]
        Voiture voiture { get; set; }


        
        public int idLocataire { get; set; }
        [ForeignKey("idLocataire")]
        Locataire locataire { get; set; }
         
    }
}