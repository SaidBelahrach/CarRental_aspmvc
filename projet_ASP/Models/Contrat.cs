using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projet_ASP.Models
{
    public class Contrat
    {
        [Column("ID")]      //ces 3 sont obligatoire
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto increment
        public int idContrat { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Date début")]
        public DateTime dateDebut { get; set; }  
        
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Date Fin")]
        public DateTime dateFin { get; set; }


        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "téléphone")]
        public string tel { get; set; }
    }
}