using DentistAPI.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistAPI.Models
{
    public class Diagnosis : EntityBase
    {
        public ClassificationOfDisease ClassificationOfDisease { get; set; }
        public Encounter Encounter { get; set; }
        public ToothRecord ToothRecord { get; set; }
        public State State { get; set; }
        public List<ToothSurfaceRecordDiagnosis> ToothSurfaces { get; set; }
        public string Note { get; set; }
        public List<ProcedureRecord> Treatments { get; set; }
    }
}
