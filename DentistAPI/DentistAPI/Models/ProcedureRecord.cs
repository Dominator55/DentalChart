using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAPI.Models
{
    public class ProcedureRecord : EntityBase
    {
        public Procedure Procedure { get; set; }
        public Encounter Encounter { get; set; }
        public ToothRecord ToothRecord { get; set; }
        public Diagnosis Reason { get; set; }

    }
}
