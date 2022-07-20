using DoctorPatientAPI.EFConfigurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace DoctorPatientAPI.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) // passing argument to super class DbContext
        {

        }

        public DbSet<Doctor> Doctors { get; set; } // table in DB
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public DbSet<AppUser> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.LogTo(Console.WriteLine)
        //                  .UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s20703;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PatientEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new DoctorEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new PrescriptionEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new MedicamentEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new Prescription_MedicamentEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new AppUserEntityTypeConfig());
        }
    }
}
