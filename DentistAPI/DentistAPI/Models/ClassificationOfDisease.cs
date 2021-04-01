namespace DentistAPI.Models
{
    public class ClassificationOfDisease : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public Procedure DefaultTreatment { get; set; }

    }
}
