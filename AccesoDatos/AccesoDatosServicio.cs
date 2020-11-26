using AccesoDatos.Contratos;
using Modelos.DTOs;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AccesoDatosServicio : IAccesoDatosServicio
    {
        #region [Initializate]
        private Contexto _contexto;
        public AccesoDatosServicio(Contexto contexto)
        {
            _contexto = contexto;
        }
        #endregion

        #region [Retornar Servicios]
        public async Task<List<ServicioDTO>> RetornarServiciosAsync()
        {
            var servicios = from s in _contexto.Servicios
                            select new ServicioDTO
                            {
                                ServicioID = s.ServicioId,
                                Descripcion = s.Descripcion,
                                ValorServicio = s.ValorServicio,
                                Matricula = s.Vehiculo.Matricula
                            };

            return await servicios.ToListAsync();
        }
        #endregion

        #region [Retornar Servicio]
        public async Task<List<ServicioDTO>> RetornarServicioAsync(int Id)
        {
            var servicio = from s in _contexto.Servicios
                           where s.ServicioId == Id
                           select new ServicioDTO
                           {
                               ServicioID = s.ServicioId,
                               Descripcion = s.Descripcion,
                               ValorServicio = s.ValorServicio,
                               Matricula = s.Vehiculo.Matricula
                           };

            return await servicio.ToListAsync();
        }
        #endregion

        #region [Actualizar]
        public async Task<int> ActualizarServicioAsync(Servicio servicio)
        {
            int numeroRegistrosActualizados = 0;

            using (var transaccion = _contexto.Database.BeginTransaction())
            {
                try
                {
                    _contexto.Entry(servicio).State = EntityState.Modified;
                    numeroRegistrosActualizados = await _contexto.SaveChangesAsync();
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw ex.InnerException;
                }
            }
            return numeroRegistrosActualizados;
        }
        #endregion

        #region [Eliminar]
        public async Task<int> EliminarServicioAsync(int id)
        {
            int RegistrosEliminados = 0;

            try
            {
                Servicio servicio = await _contexto.Servicios.FindAsync(id);
                _contexto.Servicios.Remove(servicio);
                RegistrosEliminados = await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Se produjo un error al eliminar el Servicio {id}");
            }
            return RegistrosEliminados;
        }
        #endregion

        #region [Insertar]
        public async Task<int> InsertarServicioAsync(Servicio servicio)
        {
            int RegistrosInsertados = 0;
            try
            {
                _contexto.Servicios.Add(servicio);
                RegistrosInsertados = await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Se produjo un error al insertar el servicio {servicio.Descripcion} + {ex.Message}");
            }
            return RegistrosInsertados;
        }
        #endregion
    }
}
