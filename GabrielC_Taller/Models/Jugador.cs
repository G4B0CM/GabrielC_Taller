using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GabrielC_Taller.Models
{
    public class Jugador
    {
        [Key]
        public int ID { get; set; }

        [Required] // Añadido para asegurar que el Nombre no sea nulo
        [StringLength(100)] // Limitar la longitud del nombre
        public string Nombre { get; set; } = null!;

        [Required] // Añadido para asegurar que la Posicion no sea nula
        [StringLength(50)] // Limitar la longitud de la posición
        public string Posicion { get; set; } = null!;

        [Range(0, 100)] // Validación para la edad
        public int Edad { get; set; }

        [ForeignKey("Equipo")]
        public int IDEquipo { get; set; }

        public virtual Equipo Equipo { get; set; } = null!;
    }
}
