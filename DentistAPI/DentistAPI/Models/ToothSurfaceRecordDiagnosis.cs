using System.Collections.Generic;

namespace DentistAPI.Models
{
    public class ToothSurfaceRecordDiagnosis
    {
        public int ToothSurfaceRecordId { get; set; }
        public ToothSurfaceRecord ToothSurfaceRecord { get; set; }

        public int DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }
    }
}
