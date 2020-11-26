using Modelos.DTOs;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Contratos
{
    public interface IAccesoDatosVeniculo
    {
        Task<List<VehiculoDTO>> RetornarVehiculosAsync();
        Task<List<VehiculoDTO>> RetornarVehiculoAsync(string matricula);
        Task<int> ActualizarVehiculoAsync(Vehiculo vehiculo);
        Task<int> InsertarVehiculoAsync(Vehiculo vehiculo);
        Task<int> EliminarVehiculoAsync(int Id);
    }
}
