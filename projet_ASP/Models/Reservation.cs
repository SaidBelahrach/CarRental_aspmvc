using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required(ErrorMessage = "Date de reservation est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Date de reservation")]
        public DateTime dateReservation { get; set; }

        [Required(ErrorMessage = "Date début est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Date début")]
        public DateTime dateDebut { get; set; }

        [Required(ErrorMessage = "Date Fins est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Date Fin")]
        public DateTime dateFin { get; set; }

        //+ dateCreation

        [Required(ErrorMessage = "Type de paiement est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Type de paiement")]
        public string typeDePaiement { get; set; }

        [Required(ErrorMessage = "Coût est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Coût")]
        public Decimal cout { get; set; }

        //   [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Voiture retourné")]
        [DefaultValue(false)]
        public Boolean doesCarReturned { get; set; }

        public int idVoiture { get; set; }
        [ForeignKey("idVoiture")]
        public virtual Voiture voiture { get; set; }

        public int idLocataire { get; set; }
        [ForeignKey("idLocataire")]
        public virtual Locataire locataire { get; set; }

        public ICollection<RetourVoiture> retourVoitures { get; set; }
    }
}