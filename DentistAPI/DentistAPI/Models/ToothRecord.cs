using DentistAPI.Enums;
using System.Collections.Generic;

namespace DentistAPI.Models
{
    public class ToothRecord : EntityBase
    {
        public Tooth Tooth { get; set; }
        public Patient Patient { get; set; }
        public State State { get; set; }
        public List<ToothSurfaceRecord> ToothSurfaces { get; set; }

        public List<Diagnosis> Diagnoses { get; set; }
        public List<ProcedureRecord> ProcedureRecords { get; set; }

    }
}
