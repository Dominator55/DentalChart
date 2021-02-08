using System;
using System.Collections.Generic;
using DentistAPI.Enums;

namespace DentistAPI.Models
{
    public class ToothRecord : EntityBase
    {
        public Tooth Tooth { get; set; }
        public Patient Patient {get;set;}
        public State State { get; set; }
        public List<ToothSurfaceRecord> ToothSurfaces { get; set; }

    }
}
