
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
        public DbSet<Tooth> Teeth { get; set; }
        public DbSet<ToothSurface> ToothSurfaces { get; set; }
        public DbSet<ToothToothSurface> ToothToothSurface { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<ToothRecord> ToothRecords { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<ToothSurfaceRecordDiagnosis> ToothSurfaceRecordDiagnoses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            modelBuilder.Entity<ClassificationOfDisease>().HasKey(c => c.Id);

            #region Many to many
            #region Tooth to tooth surfaces
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
            #region Diagnoses to tooth surface records
            modelBuilder.Entity<ToothSurfaceRecordDiagnosis>()
                .HasKey(tsd => new { tsd.DiagnosisId, tsd.ToothSurfaceRecordId });

            modelBuilder.Entity<ToothSurfaceRecordDiagnosis>()
                .HasOne(tsd => tsd.ToothSurfaceRecord)
                .WithMany(ts => ts.Diagnoses)
                .HasForeignKey(tsd => tsd.ToothSurfaceRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ToothSurfaceRecordDiagnosis>()
               .HasOne(tsd => tsd.Diagnosis)
               .WithMany(d => d.ToothSurfaces)
               .HasForeignKey(tsd => tsd.DiagnosisId)
               .OnDelete(DeleteBehavior.Cascade);
            #endregion
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

            //encounter has many diagnoses
            modelBuilder.Entity<Diagnosis>()
                .HasOne(d => d.Encounter)
                .WithMany(e => e.Diagnoses)
                .OnDelete(DeleteBehavior.Cascade);
            //tooth has many diagnoses
            modelBuilder.Entity<Diagnosis>()
                .HasOne(d => d.Tooth)
                .WithMany(t => t.Diagnoses)
                .OnDelete(DeleteBehavior.Cascade);

            //diagnosis has one classification of disease
            modelBuilder.Entity<Diagnosis>()
                .HasOne(d => d.ClassificationOfDisease)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            #endregion

            ToothToothSurfaceSeed.Seed(modelBuilder);
            ToothSeed.Seed(modelBuilder);
            ToothSurfaceSeed.Seed(modelBuilder);
            PatientSeed.Seed(modelBuilder);
            ClassificationOfDiseaseSeed.Seed(modelBuilder);
        }
    }
}