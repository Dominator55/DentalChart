using System.Collections.Generic;
using DentistAPI.Enums;
namespace DentistAPI.Models
{
    public class Diagnosis : EntityBase
    {
        public ClassificationOfDisease ClassificationOfDisease { get; set; }
        public Encounter Encounter { get; set; }
        public Tooth Tooth { get; set; }
        public State State { get; set; }
        public List<ToothSurfaceRecord> ToothSurfaces { get; set; }

    }
}
