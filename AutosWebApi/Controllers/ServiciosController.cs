using LogicaNegocio;
using Modelos.DTOs;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace AutosWebApi.Controllers
{
    [RoutePrefix("api")]
    public class ServiciosController : ApiController
    {       
        
        #region [Initializate]
        private FachadaServicio  _fachadaServicio;
        public ServiciosController(FachadaServicio fachadaServicio)
        {
            _fachadaServicio = fachadaServicio;
        }
        #endregion

        #region [GET - Api/Servicios]
        /// <summary>
        /// Obtiene un listado de ::Servicios::
        /// </summary>
        /// <remarks>
        /// Listado de ::Servicios:: disponibles para cada ::Vehiculo::
        /// </remarks>        
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [Route("GetAllServicios")]
        public async Task<IHttpActionResult> GetServiciosAsync()
        {           
            return Ok(await _fachadaServicio.RetornarServiciosDTOAsync());
        }
        #endregion

        #region [GET - api/Servicio/Id]
        /// <summary>
        /// Obtiene un ::Servicio:: buscado por su ::Id::
        /// </summary>
        /// <remarks>
        /// ::Servicio:: disponible para cada ::Vehiculo::
        /// </remarks>
        /// <param name="Id">Id del SErvicio</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [Route("GetServicio")]
        [ResponseType(typeof(ServicioDTO))]        
        public async Task<IHttpActionResult> GetServicioAsync(int Id)
        {
            var servicio = await _fachadaServicio.RetornarServicioDTOAsync(Id);

            if (servicio == null)
            {
                return NotFound();
            }

            return Ok(servicio);
        }
        #endregion

        #region [PUT - api/Servicio/Id]
        /// <summary>
        /// Actualiza un ::Servicio:: por ::Id::
        /// </summary>
        /// <remarks>
        /// Actualiza un ::Servicio:: el cual es buscado por su ::Id::
        /// </remarks>
        /// <param name="id">Id del Servicio</param>
        /// <param name="servicio">Pegar la peticion</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">Not Found.</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        [ResponseType(typeof(void))]
        //[Route("PutServicio")]  
        public async Task<IHttpActionResult> PutServicioAsync(int id, Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicio.ServicioId)
            {
                return BadRequest();
            }

            var registroActualizado = await _fachadaServicio.ActualizarServicioAsync(servicio);

            if (!registroActualizado)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            return Ok(servicio);
        }
        #endregion

        #region [POST - api/Servicios]
        /// <summary>
        /// Crea un ::Servicio::
        /// </summary>
        /// <remarks>
        /// Crea ::Servicio:: asociado a un ::Vehiculo::
        /// </remarks>
        /// <param name="servicio">Pegar la peticion</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>
        /// <response code="404">Not Found.</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="409">Conflict. El objeto a crear ya existe en la BD.</response>
        [ResponseType(typeof(void))]           
        public async Task<IHttpActionResult> PostServicioAsync(Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registroInsertado = await _fachadaServicio.InsertarServicioAsync(servicio);

            return StatusCode(HttpStatusCode.Created);
        }
        #endregion

        #region [DELETE: api/Servicio/Id]
        /// <summary>
        /// Elimina un servicio buscado por su Id
        /// </summary>
        /// <remarks>
        /// Elimina un servicio de la base de datos
        /// </remarks>
        /// <param name="id">Id del Servicio</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="500">Internal Error. El servicio solicitado no existe.</response>
        public async Task<IHttpActionResult> DeleteVehiculoAsync(int Id)
        {
            var cliente = await _fachadaServicio.EliminarServicioAsync(Id);

            return Ok(HttpStatusCode.OK);
        }
        #endregion

    }
}
