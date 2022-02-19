using System.ComponentModel.DataAnnotations;

namespace BackendTestWork.DTOs
{
    public class PersonDTO
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
