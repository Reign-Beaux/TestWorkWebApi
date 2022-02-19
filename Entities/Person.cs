using System.ComponentModel.DataAnnotations;

namespace BackendTestWork.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
