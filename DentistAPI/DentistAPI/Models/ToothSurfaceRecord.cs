using DentistAPI.Enums;

namespace DentistAPI.Models
{
    public class ToothSurfaceRecord : EntityBase
    {
        public ToothRecord ToothRecord { get; set; }
        public ToothSurface ToothSurface { get; set; }
        public State State { get; set; }
    }
}
