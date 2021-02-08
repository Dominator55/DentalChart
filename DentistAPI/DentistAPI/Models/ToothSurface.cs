using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentistAPI;

namespace DentistAPI.Models
{
    public class ToothSurface : EntityBase
    {
        public string Name {get; set;}
         public List<ToothToothSurface> ToothToothSurface{ get; set;}
    }
}
