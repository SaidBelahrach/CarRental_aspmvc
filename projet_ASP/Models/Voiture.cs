using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_ASP.Models
{
    //[Table("voitures")]
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

        public int idProprietaire { get; set; }
        [ForeignKey("idProprietaire")]
        public virtual Proprietaire proprietaire { get; set; }


        public ICollection<Reservation> reservations { get; set; }
    }

}
/*  
 
[Required]
        [Range(0, 20)]
        [Display(Name = "Number of stock")]
        public int stock { set; get; }

        public int NumberAvailable { set; get; }

        public carType carType { get; set; }       

        [Display(Name ="Type of Car")]
        public int carTypeId { get; set; }


 public class carType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
*/