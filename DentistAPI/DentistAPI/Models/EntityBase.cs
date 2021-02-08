using System.ComponentModel.DataAnnotations;


namespace DentistAPI.Models
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
