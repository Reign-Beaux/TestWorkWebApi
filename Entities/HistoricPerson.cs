using System.ComponentModel.DataAnnotations;

namespace BackendTestWork.Entities
{
    public class HistoricPerson
    {
        public int Id { get; set; }
        public DateTime FechaCambio { get; set; }
        public int PersonId { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}
