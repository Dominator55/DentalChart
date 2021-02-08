using System;
using System.Collections.Generic;

namespace DentistAPI.Models
{
    public class Tooth : EntityBase
    {
        public string Localization{get; set;}
        public bool Deciduous {get; set;}

        public List<ToothToothSurface> ToothToothSurface { get; set;}
    }
}
