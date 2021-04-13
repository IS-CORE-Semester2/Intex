using Intex.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intex.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public ApplicationDbContext()
        { }

        public static ApplicationDbContext Create() //Add this change
        {
            return new ApplicationDbContext();
        }

        //Bring in sets of Burials and BioSamples
        public DbSet<Burials> Burials { get; set; }
        public DbSet<BioSamples> BioSamples { get; set; }
        public DbSet<OracleSpreads> OracleSpreads { get; set; }
        public DbSet<Cranial2002> Cranial2002s { get; set; }
        public DbSet<C14Data> C14Datas { get; set; }
        public DbSet<PDFFile> PDFFiles { get; set; }
        public DbSet<Exhumation> Exhumations { get; set; }


        //Change default SQL behavior from cascading deletion to "no action"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
