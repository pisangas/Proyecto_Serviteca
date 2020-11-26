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
    public class AccesoDatosVehiculo : IAccesoDatosVeniculo
    {
        #region [Inicializate]
        private Contexto _contexto;
        public AccesoDatosVehiculo(Contexto contexto)
        {
            _contexto = contexto;
        }
        #endregion

        #region [Retornar Vehiculos]
        public async Task<List<VehiculoDTO>> RetornarVehiculosAsync()
        {
            var vehiculos = from v in _contexto.Vehiculos
                           select new VehiculoDTO
                           {
                               VehiculoId = v.VehiculoId,
                               Kilometraje = v.Kilometraje,
                               Matricula = v.Matricula,
                               CedulaPropietario = v.cliente.Cedula,
                               NombrePropietario = v.cliente.Nombre + " " + v.cliente.Apellido                          
                           };

            return await vehiculos.ToListAsync();
        }
        #endregion

        #region [Retornar Vehiculo]
        public async Task<List<VehiculoDTO>> RetornarVehiculoAsync(string matricula)
        {
            var vehiculo = from v in _contexto.Vehiculos
                          where v.Matricula == matricula
                          select new VehiculoDTO
                          {
                              VehiculoId = v.VehiculoId,
                              Kilometraje = v.Kilometraje,
                              Matricula = v.Matricula,
                              CedulaPropietario = v.cliente.Cedula,
                              NombrePropietario = v.cliente.Nombre + " " + v.cliente.Apellido
                          };

            return await vehiculo.ToListAsync();
        }
        #endregion

        #region [Actualizar]
        public async Task<int> ActualizarVehiculoAsync(Vehiculo vehiculo)
        {
            int numeroRegistrosActualizados = 0;

            using (var transaccion = _contexto.Database.BeginTransaction())
            {
                try
                {
                    _contexto.Entry(vehiculo).State = EntityState.Modified;
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
        public async Task<int> EliminarVehiculoAsync(int id)
        {
            int RegistrosEliminados = 0;

            try
            {
                Vehiculo vehiculo = await _contexto.Vehiculos.FindAsync(id);
                _contexto.Vehiculos.Remove(vehiculo);
                RegistrosEliminados = await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Se produjo un error al eliminar el vehiculo {id} + {ex.Message}");
            }
            return RegistrosEliminados;
        }
        #endregion

        #region [Insertar]
        public async Task<int> InsertarVehiculoAsync(Vehiculo vehiculo)
        {
            int RegistrosInsertados = 0;
            try
            {
                _contexto.Vehiculos.Add(vehiculo);
                RegistrosInsertados = await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"Se produjo un error al insertar el Vehiculo de matricula {vehiculo.Matricula} + {ex.Message}");
            }

            return RegistrosInsertados;
        }
        #endregion
    }
}
