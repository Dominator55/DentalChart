using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAPI.Models
{
    public class Procedure: EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
} 
