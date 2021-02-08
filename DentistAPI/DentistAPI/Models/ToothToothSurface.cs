namespace DentistAPI.Models
{
    public class ToothToothSurface
    {
        public int ToothId { get; set; }
        public Tooth Tooth { get; set; }
        public int SurfaceId { get; set; }
        public ToothSurface Surface { get; set; }
    }
}
