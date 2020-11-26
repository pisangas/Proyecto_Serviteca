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
    public class VehiculosController : ApiController
    {        
        #region [Initializate]
        private FachadaVehiculo _fachadaVehiculo;
        public VehiculosController(FachadaVehiculo fachadaVehiculo)
        {
            _fachadaVehiculo = fachadaVehiculo;
        }
        #endregion

        #region [GET - Api/Vehiculos]
        /// <summary>
        /// Obtiene un listado de ::Vehiculos::
        /// </summary>
        /// <remarks>
        /// Listado de ::Vehiculos::
        /// </remarks>        
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [Route("GetAllVehiculos")]
        public async Task<IHttpActionResult> GetVehiculosAsync()
        {
            return Ok(await _fachadaVehiculo.RetornarVehiculosDTOAsync());
        }
        #endregion

        #region [GET - api/Vehiculos/matricula]
        /// <summary>
        /// Obtiene un ::Vehiculo:: buscado por su ::Matricula::
        /// </summary>
        /// <remarks>
        /// ::Vehiculo:: buscado por ::Matricula::
        /// </remarks>
        /// <param name="matricula">Matricula del Vehiculo</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [Route("GetVehiculo")]
        [ResponseType(typeof(VehiculoDTO))]
        public async Task<IHttpActionResult> GetVehiculoAsync(string matricula)
        {
            var vehiculo = await _fachadaVehiculo.RetornarVehiculoDTOAsync(matricula);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return Ok(vehiculo);
        }
        #endregion

        #region [PUT - api/Vehiculos/Id]
        /// <summary>
        /// Actualiza un ::Vehiculos:: deacuerdo a su ::Matricula::
        /// </summary>
        /// <remarks>
        /// Actualiza un ::Vehiculos:: el cual es buscado por su ::Matricula::
        /// </remarks>
        /// <param name="id">Id del Vehiculo</param>
        /// <param name="vehiculo">Pegar ejemplo</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">Not Found.</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVehiculoAsync(int id, Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehiculo.VehiculoId)
            {
                return BadRequest();
            }

            var registroActualizado = await _fachadaVehiculo.ActualizarVehiculo(vehiculo);

            if (!registroActualizado)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            return Ok(vehiculo);
        }
        #endregion

        #region [POST - api/Vehiculos]
        /// <summary>
        /// Crea un ::Vehiculos::
        /// </summary>
        /// <remarks>
        /// Crea ::Vehiculos:: asociado a un ::Cliente::
        /// </remarks>
        /// <param name="vehiculo">Pegar peticion</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>
        /// <response code="404">Not Found.</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="409">Conflict. El objeto a crear ya existe en la BD.</response>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostVehiculoAsync(Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registroInsertado = await _fachadaVehiculo.InsertarVehiculoAsync(vehiculo);

            return Ok(vehiculo);
        }
        #endregion

        #region [DELETE: api/Vehiculos/Id]
        /// <summary>
        /// Elimina un ::Vehiculos:: buscado por su ::Matricula::
        /// </summary>
        /// <remarks>
        /// Elimina un ::Vehiculos:: de la base de datos
        /// </remarks>
        /// <param name="Id">Id del Vehiculo</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="500">Internal Error. El ::Vehiculo:: solicitado no existe.</response>
        public async Task<IHttpActionResult> DeleteVehiculoAsync(int Id)
        {
            var cliente = await _fachadaVehiculo.EliminarCliente(Id);

            return Ok(HttpStatusCode.OK);
        }
        #endregion
    }
}
