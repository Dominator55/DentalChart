using System.Collections.Generic;
using DentistAPI.Models;
using Microsoft.EntityFrameworkCore;
using DentistAPI.Enums;

namespace DentistAPI.Seeds
{
    public class PatientSeed
    {
        private static readonly List<Patient> Data = new List<Patient>
        {
            new Patient
            {
                Id = 1,
                NationalId = "935617/4905",
                Name = "Jana Nováková",
                Address = "Jabloňová 16 Brno 62100",
                Phone = "655 475 877",
                Email = "jana.novakova@gmail.com",
                Age = 28,
                healthInsuranceCompany = HealthInsuranceCompanies.VZP
            }
        };
        public static void Seed(ModelBuilder modelBuilder)
            => modelBuilder.Entity<Patient>().HasData(Data);
    }
}
