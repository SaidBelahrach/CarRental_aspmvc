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


        [Required(ErrorMessageResourceType = typeof(Resources.Models.RetourVoiture), ErrorMessageResourceName = "dateRetourReq")]
        [Display(Name = "dateRetour", ResourceType = typeof(Resources.Models.RetourVoiture))]
        public DateTime dateRetour { get; set; }

        //[Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "etat", ResourceType = typeof(Resources.Models.RetourVoiture))]
        public string etat { get; set; }

        //  [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "pinalise", ResourceType = typeof(Resources.Models.RetourVoiture))]
        [DefaultValue(false)]
        public Boolean pinalise { get; set; }

        [Display(Name = "amende", ResourceType = typeof(Resources.Models.RetourVoiture))]
        [DefaultValue(0)]
        public Decimal amende { get; set; }

        public int idContrat { get; set; }
        [ForeignKey("idContrat")]
        public virtual Reservation Reservation { get; set; }

    }
}