using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_ASP.Models
{
    public class Reservation
    {
        //[Column("ID")]      //ces 3 sont obligatoires
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idContrat { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Date de reservation")]
        public DateTime dateReservation { get; set; }

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


        public int idVoiture { get; set; }
        [ForeignKey("idVoiture")]
        Voiture voiture { get; set; }



        public int idLocataire { get; set; }
        [ForeignKey("idLocataire")]
        Locataire locataire { get; set; }

    }
}