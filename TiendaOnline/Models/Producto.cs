using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500)]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio base es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal PrecioBase { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio con descuento debe ser mayor que cero")]
        public decimal? PrecioDescuento { get; set; }

        [StringLength(300)]
        [Display(Name = "Imagen (URL)")]
        public string? ImagenUrl { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
