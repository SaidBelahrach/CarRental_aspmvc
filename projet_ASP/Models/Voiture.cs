using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_ASP.Models
{
    //[Table("voitures")] 
    public class Voiture
    {
        //[Column("ID")]      //ces 3 sont obligatoire
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "idVoiture")]
        public int idVoiture { get; set; }


        //  [Required(ErrorMessage = "matricule est obligatoire", AllowEmptyStrings = false)]
        // [Display(Name = "Matricule")]

        [Required(ErrorMessageResourceType = typeof(projet_ASP.Resources.Models.Voitures), ErrorMessageResourceName = "matriculeReq")]
        [Display(Name = "matricule", ResourceType = typeof(projet_ASP.Resources.Models.Voitures))]
        public string matricule { get; set; }


        // [Required(ErrorMessage = "Marque est obligatoire", AllowEmptyStrings = false)]
        //[Display(Name = "Marque")]

        [Required(ErrorMessageResourceType = typeof(projet_ASP.Resources.Models.Voitures), ErrorMessageResourceName = "marqueReq")]
        [Display(Name = "marque", ResourceType = typeof(projet_ASP.Resources.Models.Voitures))]
        public string marque { get; set; }


        //[Required(ErrorMessage = "Modèle est obligatoire", AllowEmptyStrings = false)]
        //Display(Name = "Modèle")]

        [Required(ErrorMessageResourceType = typeof(projet_ASP.Resources.Models.Voitures), ErrorMessageResourceName = "modelReq")]
        [Display(Name = "model", ResourceType = typeof(projet_ASP.Resources.Models.Voitures))]
        public string model { get; set; }

        [Required(ErrorMessageResourceType = typeof(projet_ASP.Resources.Models.Voitures), ErrorMessageResourceName = "couleurReq")]
        [Display(Name = "couleur", ResourceType = typeof(projet_ASP.Resources.Models.Voitures))]
        public string couleur { get; set; }


        [Required(ErrorMessageResourceType = typeof(projet_ASP.Resources.Models.Voitures), ErrorMessageResourceName = "nbPlacesReq")]
        [Display(Name = "nbPlaces", ResourceType = typeof(projet_ASP.Resources.Models.Voitures))]
        public int nbPlaces { get; set; }

        [Display(Name = "automatique", ResourceType = typeof(projet_ASP.Resources.Models.Voitures))]
        public Boolean automatique { get; set; }

        [Required(ErrorMessageResourceType = typeof(projet_ASP.Resources.Models.Voitures), ErrorMessageResourceName = "coutParJourReq")]
        [Display(Name = "coutParJour", ResourceType = typeof(projet_ASP.Resources.Models.Voitures))]
        public String coutParJour { get; set; }

        [Display(Name = "disponible", ResourceType = typeof(projet_ASP.Resources.Models.Voitures))]
        [DefaultValue(true)]
        public Boolean disponible { get; set; }

        [Display(Name = "image", ResourceType = typeof(projet_ASP.Resources.Models.Voitures))]
        public byte[] image { get; set; } //https://www.aurigma.com/upload-suite/developers/aspnet-mvc/how-to-upload-files-in-aspnet-mvc
                                          //https://stackoverflow.com/questions/26347705/saving-images-to-database-with-asp-net-mvc-4-entity-framework

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