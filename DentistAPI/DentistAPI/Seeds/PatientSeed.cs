using DentistAPI.Enums;
using DentistAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DentistAPI.Seeds
{
    public class PatientSeed
    {
        private static readonly List<Patient> Data = new List<Patient>
        {
            new Patient
            {
                  Id= 1,
                  NationalId= "880824/5006",
                  Name= "Ivan Rus",
                  Address= "Kartouzská 8 Brno",
                  Email= "rus@email.cz",
                  Phone= "+420 370 279 403",
                  Age= 0,
                  HealthInsuranceCompany= HealthInsuranceCompanies.VZP,
                  PersonalAnamnesis= "Testovací osobní anamnéza",
                  Allergies= "jahody - opuchne v obličeji",
                  PharmacologicalAnamnesis= "xyzal",
                  Smoker= true,
                  SmokingDetail= "krabička denně",
                  Alcohol= true,
                  AlcoholDetail= "flaška vodky denně",
                  Drugs= false,
                  DrugsDetail= false
            }
        };
        public static void Seed(ModelBuilder modelBuilder)
            => modelBuilder.Entity<Patient>().HasData(Data);
    }
}
