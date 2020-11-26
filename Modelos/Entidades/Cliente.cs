using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entidades
{
    [Table("Clientes")]
    public class Cliente
    {
        public int ClienteId { get; set; }

        [StringLength(20, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres ", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string Nombre { get; set; }

        [StringLength(20, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres ", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
