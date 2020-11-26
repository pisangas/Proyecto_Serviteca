using AccesoDatos.Contratos;
using Modelos.DTOs;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AccesoDatosCliente : IAccesoDatosCliente
    {
        #region [Inicializate]
        private Contexto _contexto;
        public AccesoDatosCliente(Contexto contexto)
        {
            _contexto = contexto;

        }
        #endregion               

        #region [RetornarClientes]
        public async Task<List<ClienteDTO>> RetornarClientesAsync()
        {
            var clientes = from c in _contexto.Clientes
                      select new ClienteDTO
                      {
                          ClienteId = c.ClienteId,
                          Nombre = c.Nombre,
                          Apellido = c.Apellido,
                          Cedula = c.Cedula,
                          Telefono = c.Telefono,
                          Direccion = c.Direccion,
                          Edad = c.Edad
                      };

            return await clientes.ToListAsync();
        }
        #endregion

        #region [RetornarCliente]
        public async Task<List<ClienteDTO>> RetornarClienteAsync(int cedula)
        {
            var cliente = from c in _contexto.Clientes
                          where c.Cedula == cedula
                          select new ClienteDTO
                          {
                              ClienteId = c.ClienteId,
                              Nombre = c.Nombre,
                              Apellido = c.Apellido,
                              Cedula = c.Cedula,
                              Telefono = c.Telefono,
                              Direccion = c.Direccion,
                              Edad = c.Edad
                          };

            return await cliente.ToListAsync();
        }
        #endregion

        #region [Actualizar]
        public async Task<int> ActualizarClienteAsync(Cliente cliente)
        {
            int numeroRegistrosActualizados = 0;

            using (var transaccion = _contexto.Database.BeginTransaction())
            {
                try
                {
                    _contexto.Entry(cliente).State = EntityState.Modified;
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

        #region [Insertar]
        public async Task<int> InsertarClienteAsync(Cliente cliente)
        {
            int RegistrosInsertados = 0;
            try
            {
                _contexto.Clientes.Add(cliente);
                RegistrosInsertados = await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Se produjo un error al insertar el Cliente de cedula {cliente.Cedula} {ex.Message}");
            }
            return RegistrosInsertados;
        }
        #endregion        

        #region [Eliminar]
        public async Task<int> EliminarClienteAsync(int Id)
        {
            int RegistrosEliminados = 0;
            try
            {
                Cliente cliente = await _contexto.Clientes.FindAsync(Id);
                _contexto.Clientes.Remove(cliente);
                RegistrosEliminados = await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Se produjo un error al eliminar el cliente {Id} + {ex.Message}");
            }
            return RegistrosEliminados;
        }
        #endregion
       
    }
}