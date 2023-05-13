using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Parcial3_LondonoValenciaSebastian.DAL.Entities
{
    public class VehicleDetails
    {
        [Key]
        public virtual Guid Id { get; set; }

        [ForeignKey(nameof(Vehicle))]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        [Display(Name = "Fecha de Entrega")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime DeliveryDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Precio del Servicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal PriceService { get; set; }
    }
}
