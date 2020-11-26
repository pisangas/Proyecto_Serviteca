using Modelos.DTOs;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Contratos
{
    public interface IAccesoDatosServicio
    {
        Task<List<ServicioDTO>> RetornarServiciosAsync();
        Task<List<ServicioDTO>> RetornarServicioAsync(int id);
        Task<int> ActualizarServicioAsync(Servicio servicio);
        Task<int> InsertarServicioAsync(Servicio servicio);
        Task<int> EliminarServicioAsync(int Id);
    }
}
