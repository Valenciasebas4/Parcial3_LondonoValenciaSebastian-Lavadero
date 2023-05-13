using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Parcial3_LondonoValenciaSebastian.DAL.Entities
{
    public class Vehicle
    {
        [Key]
        public virtual Guid Id { get; set; }



        [ForeignKey(nameof(Service))]
        [Display(Name = "Servicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid ServiceId { get; set; }

        [Display(Name = "Propietario")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Owner { get; set; }

        [Display(Name = "Numero de Placa")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NumberPlate { get; set; }

        public virtual Service Service { get; set; }


    }
}
