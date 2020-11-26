using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTOs
{
    public class VehiculoDTO
    {
        public int VehiculoId { get; set; }
        public int Kilometraje { get; set; }
        public string Matricula { get; set; }
        public int CedulaPropietario { get; set; }
        public string NombrePropietario { get; set; } 
    }
}
