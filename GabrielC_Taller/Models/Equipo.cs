using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GabrielC_Taller.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        [MaxLength(100)] 
        public string Nombre { get; set; } = null!;

        [MaxLength(100)] 
        public string Ciudad { get; set; } = null!;

        [Range(0, int.MaxValue)] 
        public int Titulos { get; set; }

        public bool Extranjeros { get; set; }

        [ForeignKey("Estadio")]
        public int IDEstadio { get; set; }

        public virtual Estadio? Estadio { get; set; } = null!;
    }
}
