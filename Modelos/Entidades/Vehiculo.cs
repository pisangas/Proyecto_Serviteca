using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entidades
{
    [Table("Vehiculos")]
    public class Vehiculo
    {
        public int VehiculoId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public int Kilometraje { get; set; }

        [StringLength(10, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres ")]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string Matricula { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}
