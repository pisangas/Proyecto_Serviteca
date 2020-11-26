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
    public class FachadaServicio
    {
        #region [Initialize]
        private IAccesoDatosServicio _accesoDatosServicio;
        public FachadaServicio(IAccesoDatosServicio accesoDatosServicio)
        {
            _accesoDatosServicio = accesoDatosServicio;
        }
        #endregion

        #region [Retornar Servicios]
        public async Task<List<ServicioDTO>> RetornarServiciosDTOAsync()
        {
            return await _accesoDatosServicio.RetornarServiciosAsync();
        }
        #endregion

        #region [Retornar Servicio]
        public async Task<List<ServicioDTO>> RetornarServicioDTOAsync(int Id)
        {
            return await _accesoDatosServicio.RetornarServicioAsync(Id);
        }
        #endregion

        #region [Insertar]
        public async Task<bool> InsertarServicioAsync(Servicio servicio)
        {
            try
            {
                return await _accesoDatosServicio.InsertarServicioAsync(servicio) == 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region [Actualizar]
        public async Task<bool> ActualizarServicioAsync(Servicio servicio)
        {
            try
            {
                return await _accesoDatosServicio.ActualizarServicioAsync(servicio) == 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region [Eliminar]
        public async Task<bool> EliminarServicioAsync(int id)
        {
            try
            {
                return await _accesoDatosServicio.EliminarServicioAsync(id) == 1;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
