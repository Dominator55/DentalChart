using DentistAPI.Enums;
using System.Collections.Generic;

namespace DentistAPI.Models
{
    public class Patient : EntityBase
    {
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public HealthInsuranceCompanies healthInsuranceCompany { get; set; }
        public string PersonalAnamnesis { get; set; }
        public string Allergies { get; set; }
        public string PharmacologicalAnamnesis { get; set; }
        public bool Smoker { get; set; }
        public string SmokingDetail { get; set; }
        public bool Alcohol { get; set; }
        public string AlcoholDetail { get; set; }
        public bool Drugs { get; set; }
        public bool DrugsDetail { get; set; }

        public List<Encounter> Encounters { get; set; }
        public List<ToothRecord> ToothRecords { get; set; }


    }
}
