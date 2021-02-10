using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_ASP.Models
{
    [Table("retoursVoitures")]
    public class RetourVoiture
    {
        //    [Column("ID")]
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRetour { get; set; }

        [Required(ErrorMessage = "Date de retour est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Date de retour")]
        public DateTime dateRetour { get; set; }

        //[Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Etat de voiture après retour")] //est il endomagé ou non
        public string etat { get; set; }

        //  [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Pinalisé")]
        [DefaultValue(false)]
        public Boolean pinalise { get; set; }

        [Display(Name = "Amende")]
        [DefaultValue(0)]
        public Decimal amende { get; set; }

        public int idContrat { get; set; }
        [ForeignKey("idContrat")]
        public virtual Reservation Reservation { get; set; }

    }
}