using System;
using System.Collections.Generic;

namespace DentistAPI.Models
{
    public class Encounter : EntityBase
    {
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
        public string ReportText { get; set; }
        public List<Diagnosis> Diagnoses { get; set; }
    }
}
