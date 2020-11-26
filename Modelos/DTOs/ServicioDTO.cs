using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTOs
{
    public class ServicioDTO
    {
        public int ServicioID { get; set; }
        public string Descripcion{ get; set; }
        public int ValorServicio { get; set; }
        public string Matricula { get; set; }
    }
}
