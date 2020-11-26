using Modelos.DTOs;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Contratos
{
    public interface IAccesoDatosCliente
    {
        Task<List<ClienteDTO>> RetornarClientesAsync();
        Task<List<ClienteDTO>> RetornarClienteAsync(int cedula);
        Task<int> ActualizarClienteAsync(Cliente cliente);
        Task<int> InsertarClienteAsync(Cliente cliente);
        Task<int> EliminarClienteAsync(int Id);
        

    }
}
