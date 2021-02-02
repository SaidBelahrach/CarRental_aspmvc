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
        [Display(Name = "Matricule")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string matricule { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Marque")]
        public string marque { get; set; }


        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Modèle")]
        public string model { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Couleur")]
        public string couleur { get; set; }


        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Nombre de places")]
        public int nbPlaces { get; set; }

        [Display(Name = "Type")]
        public Boolean automatique { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Cout par jour")]
        public Decimal coutParJour { get; set; }

        [Display(Name = "Disponibilité")]
        public Boolean disponible { get; set; }


        [Display(Name = "Image de voiture")]
        public string imagePath { get; set; } //https://www.aurigma.com/upload-suite/developers/aspnet-mvc/how-to-upload-files-in-aspnet-mvc
         

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