using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GabrielC_Taller.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }

        [Required] // Aseguramos que el Nombre no sea nulo
        [MaxLength(100)] // Limitar la longitud del nombre
        public string Nombre { get; set; } = null!;

        [MaxLength(100)] // Limitar la longitud de la ciudad
        public string Ciudad { get; set; } = null!;

        [Range(0, int.MaxValue)] // Validación para el número de títulos
        public int Titulos { get; set; }

        public bool Extranjeros { get; set; }

        [ForeignKey("Estadio")]
        public int IDEstadio { get; set; }

        public virtual Estadio Estadio { get; set; } = null!;
    }
}
