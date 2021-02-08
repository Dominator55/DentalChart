using DentistAPI.Enums;
using System.Collections.Generic;
namespace DentistAPI.Models
{
    public class Diagnosis : EntityBase
    {
        public ClassificationOfDisease ClassificationOfDisease { get; set; }
        public Encounter Encounter { get; set; }
        public ToothRecord Tooth { get; set; }
        public State State { get; set; }
        public List<ToothSurfaceRecordDiagnosis> ToothSurfaces { get; set; }

    }
}
