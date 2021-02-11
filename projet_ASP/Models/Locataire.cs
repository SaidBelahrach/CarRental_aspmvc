using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_ASP.Models
{
    [Table("locataires")]
    public class Locataire
    {
        // [Column("ID")]      //ces 3 sont obligatoire
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto increment
        public int idLocataire { get; set; }


        [Required(ErrorMessageResourceType = typeof(projet_ASP.Resources.Models.Locataire), ErrorMessageResourceName = "NpermisRequired")]
        [Display(Name = "Npermis", ResourceType = typeof(projet_ASP.Resources.Models.Locataire))]
        public int Npermis { get; set; }


        public ICollection<Reservation> reservations { get; set; }
        public ICollection<Reclamation> Reclamations { get; set; } //un proprietaire peut avoir plusieurs voitures



        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}