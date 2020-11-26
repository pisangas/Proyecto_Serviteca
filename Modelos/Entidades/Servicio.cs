using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entidades
{
    [Table("Servicios")]
    public class Servicio
    {
        public int ServicioId { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public int ValorServicio { get; set; }

        public int VehiculoId { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
