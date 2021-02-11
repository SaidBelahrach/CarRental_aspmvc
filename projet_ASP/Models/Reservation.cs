using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace projet_ASP.Models
{
    public class Reservation
    {
        //[Column("ID")]    
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idContrat { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Models.Reservation), ErrorMessageResourceName = "dateReservationReq")]
        [Display(Name = "dateReservation", ResourceType = typeof(Resources.Models.Reservation))]
        public DateTime dateReservation { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Models.Reservation), ErrorMessageResourceName = "dateDebutReq")]
        [Display(Name = "dateDebut", ResourceType = typeof(Resources.Models.Reservation))]
        public DateTime dateDebut { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Models.Reservation), 
                  ErrorMessageResourceName = "dateFinReq")]
        [Display(Name = "dateFin", ResourceType = typeof(Resources.Models.Reservation))]
        public DateTime dateFin { get; set; }

        //+ dateCreation

        [Required(ErrorMessageResourceType = typeof(Resources.Models.Reservation),
                  ErrorMessageResourceName = "typeDePaiementReq")]
        [Display(Name = "typeDePaiement", ResourceType = typeof(Resources.Models.Reservation))]
        public string typeDePaiement { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Models.Reservation),
                  ErrorMessageResourceName = "coutReq")]
        [Display(Name = "cout", ResourceType = typeof(Resources.Models.Reservation))]
        public Decimal cout { get; set; }

        //   [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "doesCarReturned", ResourceType = typeof(Resources.Models.Reservation))]
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