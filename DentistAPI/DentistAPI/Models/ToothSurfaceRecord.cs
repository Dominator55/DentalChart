using DentistAPI.Enums;
using System.Collections.Generic;

namespace DentistAPI.Models
{
    public class ToothSurfaceRecord : EntityBase
    {
        public ToothRecord ToothRecord { get; set; }
        public ToothSurface ToothSurface { get; set; }
        public State State { get; set; }
        public List<ToothSurfaceRecordDiagnosis> Diagnoses { get; set; }
    }
}
