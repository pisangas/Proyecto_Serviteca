using AccesoDatos.Contratos;
using Modelos.DTOs;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class FachadaCliente
    {
        #region [Initialize]
        private IAccesoDatosCliente _accesoDatosCliente;
        public FachadaCliente(IAccesoDatosCliente accesoDatosCliente)
        {
            _accesoDatosCliente = accesoDatosCliente;
        }
        #endregion

        #region [Retornar Clientes]
        public async Task<List<ClienteDTO>> RetornarClientesAsync()
        {
            return await _accesoDatosCliente.RetornarClientesAsync();
        }
        #endregion

        #region [Retornar Cliente]
        public async Task<List<ClienteDTO>> RetornarClienteAsync(int cedula)
        {
            return await _accesoDatosCliente.RetornarClienteAsync(cedula);
        }

        #endregion       

        #region [Actualizar]
        public async Task<bool> ActualizarClienteAsync(Cliente cliente)
        {
            try
            {
                return await _accesoDatosCliente.ActualizarClienteAsync(cliente) == 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region [Insertar]
        public async Task<bool> InsertarClienteAsync(Cliente cliente)
        {
            try
            {
                return await _accesoDatosCliente.InsertarClienteAsync(cliente) == 1;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }            
        }
        #endregion        

        #region [Eliminar]
        public async Task<bool> EliminarClienteAsync(int Id)
        {
            try
            {
                return await _accesoDatosCliente.EliminarClienteAsync(Id) == 1;
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }            
        }
        #endregion
    }
}
