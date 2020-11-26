using LogicaNegocio;
using Modelos.DTOs;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace AutosWebApi.Controllers
{
    [RoutePrefix("api")]
    public class ClientesController : ApiController
    {
        #region [Initializate]
        private FachadaCliente _fachadaCliente;
        public ClientesController(FachadaCliente fachadaCliente)
        {
            _fachadaCliente = fachadaCliente;
        }
        #endregion

        #region [GET - Api/Clientes]
        /// <summary>
        /// Obtiene un listado de ::Clientes::
        /// </summary>
        /// <remarks>
        /// Listado de ::Clientes::
        /// </remarks>        
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>

        [Route("GetAllClientes")]        
        public async Task<IHttpActionResult> GetClientesAsync()
        {
            return Ok(await _fachadaCliente.RetornarClientesAsync());
        }
        #endregion

        #region [GET - api/Clientes/Cedula]
        /// <summary>
        /// Obtiene un ::Cliente:: buscado por su ::Cedula::
        /// </summary>
        /// <remarks>
        /// ::Cliente:: buscado por ::Cedula::
        /// </remarks>
        /// <param name="cedula">Cedula del Cliente</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [Route("GetCliente")]
        [ResponseType(typeof(ClienteDTO))]
        public async Task<IHttpActionResult> GetClienteAsync(int cedula)
        {
            var cliente = await _fachadaCliente.RetornarClienteAsync(cedula);

            if (cliente == null)
            {
                return NotFound();
            }
            
            return Ok(cliente);
        }
        #endregion

        #region [PUT - api/Clientes/Id]
        /// <summary>
        /// Actualiza un ::Cliente:: deacuerdo a su ::Cedula::
        /// </summary>
        /// <remarks>
        /// Actualiza un ::Cliente:: el cual es buscado por su ::Cedula::
        /// </remarks>
        /// <param name="id">Id del Cliente</param>
        /// <param name="cliente">Pegar peticion</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">Not Found.</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClienteAsync(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            var registroActualizado = await _fachadaCliente.ActualizarClienteAsync(cliente);

            if (!registroActualizado)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            return Ok(cliente);
        }
        #endregion

        #region [POST - api/Clientes]
        /// <summary>
        /// Crea un ::Cliente::
        /// </summary>
        /// <remarks>
        /// Crea ::Cliente::
        /// </remarks>
        /// <param name="cliente">Pegar peticion</param>        
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>
        /// <response code="404">Not Found.</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="409">Conflict. El objeto a crear ya existe en la BD.</response>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostClienteAsync(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }           

            var registroInsertado = await _fachadaCliente.InsertarClienteAsync(cliente);

            return Ok(cliente);
        }
        #endregion

        #region [DELETE: api/Clientes/Id]
        /// <summary>
        /// Elimina un ::Cliente:: buscado por su ::Cedula::
        /// </summary>
        /// <remarks>
        /// Elimina un ::Cliente:: de la base de datos
        /// </remarks>
        /// <param name="Id">Id del Cliente</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="500">Internal Error. El ::Cliente:: solicitado no existe.</response>
        public async Task<IHttpActionResult> DeleteClienteAsync(int Id)
        {
            var cliente = await _fachadaCliente.EliminarClienteAsync(Id);                       
            
            return Ok(HttpStatusCode.OK);
        }
        #endregion
    }
}
