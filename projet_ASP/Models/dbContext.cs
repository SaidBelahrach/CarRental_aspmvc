using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace projet_ASP.Models
{
    public class dbContext: DbContext
    {
        public dbContext() : base("name=project_db") { }
        public virtual DbSet<Voiture> Voitures { get; set; }
        public virtual DbSet<Proprietaire> Proprietaires { get; set; }
        public virtual DbSet<Locataire> Locataires { get; set; }
        public virtual DbSet<Contrat> Contrats { get; set; }
        public virtual DbSet<RetourVoiture> RetourVoitures { get; set; }

    }
}