using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_ASP.Models
{
    public class ListeNoire
    {
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto increment
        public int idListeNoire { get; set; }

        //[Required(ErrorMessageResourceType = typeof(projet_ASP.Resources.Models.Locataire), ErrorMessageResourceName = "NpermisRequired")]
        [Display(Name = "Npermis", ResourceType = typeof(projet_ASP.Resources.Models.Locataire))]
        public string description { get; set; }


        public ICollection<ApplicationUser> users { get; set; }

            public int idAdmin { get; set; }
            [ForeignKey("idAdmin")]
            public virtual Admin Admin { get; set; }

    }
}