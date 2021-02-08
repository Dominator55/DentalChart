
using DentistAPI.Models;
using DentistAPI.Seeds;
using Microsoft.EntityFrameworkCore;
namespace DentistAPI
{
    public class DentistAPIContext : DbContext
    {

        public DentistAPIContext(DbContextOptions<DentistAPIContext> options) : base(options)
        {
        }
        public DbSet<Tooth> Tooth { get; set; }
        public DbSet<ToothSurface> ToothSurfaces { get; set; }
        public DbSet<DentistAPI.Models.ToothToothSurface> ToothToothSurface { get; set; }

        public DbSet<DentistAPI.Models.Patient> Patient { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Many to many

            modelBuilder.Entity<ToothToothSurface>()
                .HasKey(ts => new { ts.ToothId, ts.SurfaceId });
            modelBuilder.Entity<ToothToothSurface>()
                .HasOne(ts => ts.Tooth)
                .WithMany(t => t.ToothToothSurface)
                .HasForeignKey(ts => ts.ToothId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ToothToothSurface>()
                .HasOne(ts => ts.Surface)
                .WithMany(s => s.ToothToothSurface)
                .HasForeignKey(ts => ts.SurfaceId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region One to many
            //patient has many encounters
            modelBuilder.Entity<Encounter>()
                .HasOne(e => e.Patient)
                .WithMany(p => p.Encounters)
                .OnDelete(DeleteBehavior.Cascade);

            //encounter has many diagnoses
            modelBuilder.Entity<Diagnosis>()
               .HasOne(d => d.Encounter)
               .WithMany(e => e.Diagnoses)
               .OnDelete(DeleteBehavior.Cascade);


            //patient has many tooth records
            modelBuilder.Entity<ToothRecord>()
                .HasOne(t => t.Patient)
                .WithMany(p => p.ToothRecords)
                .OnDelete(DeleteBehavior.Cascade);

            //tooth record has many surface records
            modelBuilder.Entity<ToothSurfaceRecord>()
               .HasOne(s => s.ToothRecord)
               .WithMany(t => t.ToothSurfaces)
               .OnDelete(DeleteBehavior.Cascade);



            #endregion

            ToothToothSurfaceSeed.Seed(modelBuilder);
            ToothSeed.Seed(modelBuilder);
            ToothSurfaceSeed.Seed(modelBuilder);
            PatientSeed.Seed(modelBuilder);
        }

        public DbSet<DentistAPI.Models.ToothRecord> ToothRecord { get; set; }

    }
}