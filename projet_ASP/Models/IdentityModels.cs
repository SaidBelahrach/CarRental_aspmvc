using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace projet_ASP.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [Required(ErrorMessageResourceType = typeof(Resources.Models.ApplicationUser),
                  ErrorMessageResourceName = "nomCompletReq")]
        [Display(Name = "nomComplet", ResourceType = typeof(Resources.Models.ApplicationUser))]
        public string nomComplet { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources.Models.ApplicationUser),
                 ErrorMessageResourceName = "adresseReq")]
        [Display(Name = "adresse", ResourceType = typeof(Resources.Models.ApplicationUser))]
        public string adresse { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Models.ApplicationUser),
                  ErrorMessageResourceName = "profileTypeReq")]
        [Display(Name = "profileType", ResourceType = typeof(Resources.Models.ApplicationUser))]
        public string profileType { get; set; }

        [Display(Name = "imageBytes", ResourceType = typeof(Resources.Models.ApplicationUser))]
        public byte[] imageBytes { get; set; }

        public int? idFavoris { get; set; }
        [ForeignKey("idFavoris")]
        public virtual Favoris Favoris { get; set; }

        public int? idListeNoire { get; set; }
        [ForeignKey("idListeNoire")]
        public virtual ListeNoire ListeNoire { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType

            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public ICollection<Locataire> locataires { get; set; }
        public ICollection<Proprietaire> proprietaires { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("project_db", throwIfV1Schema: false)
        {
        }
        public virtual DbSet<Voiture> Voitures { get; set; }
        public virtual DbSet<Proprietaire> Proprietaires { get; set; }
        public virtual DbSet<Locataire> Locataires { get; set; }
        public virtual DbSet<Reservation> reservations { get; set; }
        public virtual DbSet<RetourVoiture> RetourVoitures { get; set; }
        public virtual DbSet<Reclamation> Reclamations { get; set; }
        public virtual DbSet<ListeNoire> ListeNoires { get; set; }
        public virtual DbSet<Favoris> Favoris { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}