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
    public class FachadaVehiculo
    {
        #region [Initialize]
        private IAccesoDatosVeniculo _accesoDatosVehiculo;
        public FachadaVehiculo(IAccesoDatosVeniculo accesoDatosVehiculo)
        {
            _accesoDatosVehiculo = accesoDatosVehiculo;
        }
        #endregion

        #region [Retornar Vehiculos]
        public async Task<List<VehiculoDTO>> RetornarVehiculosDTOAsync()
        {
            return await _accesoDatosVehiculo.RetornarVehiculosAsync();
        }
        #endregion

        #region [Retornar Vehiculo]
        public async Task<List<VehiculoDTO>> RetornarVehiculoDTOAsync(string matricula)
        {
            return await _accesoDatosVehiculo.RetornarVehiculoAsync(matricula);
        }
        #endregion

        #region [Insertar]
        public async Task<bool> InsertarVehiculoAsync(Vehiculo vehiculo)
        {
            try
            {
                return await _accesoDatosVehiculo.InsertarVehiculoAsync(vehiculo) == 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region [Actualizar]
        public async Task<bool> ActualizarVehiculo(Vehiculo vehiculo)
        {
            try
            {
                return await _accesoDatosVehiculo.ActualizarVehiculoAsync(vehiculo) == 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region [Eliminar]
        public async Task<bool> EliminarCliente(int id)
        {
            try
            {
                return await _accesoDatosVehiculo.EliminarVehiculoAsync(id) == 1;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
