using System.ComponentModel.DataAnnotations;

namespace BackendTestWork.DTOs
{
    public class CreatePersonDTO
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
