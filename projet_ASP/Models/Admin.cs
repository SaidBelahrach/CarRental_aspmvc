using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_ASP.Models
{
    public class Admin
    {
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID admin")]
        public int idAdmin { get; set; }


        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public ICollection<ListeNoire> listeNoires { get; set; }
        public ICollection<Favoris> Favoris { get; set; }

        /*      public Admin()
              {
                  ApplicationDbContext db = new ApplicationDbContext();
                  ListeNoire ls = new ListeNoire();
                  ls.idAdmin = idAdmin;
                  Favoris fv = new Favoris();
                  fv.idAdmin = idAdmin; 
                  db.ListeNoires.Add(ls);
                  db.Favoris.Add(fv);
                  db.SaveChanges();

              }*/
    }
}