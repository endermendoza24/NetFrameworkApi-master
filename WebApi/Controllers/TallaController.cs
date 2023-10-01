using Application.Endpoint;
using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class TallaController : ApiController
    {
        private TallaStore _tallaStore = new TallaStore();

        [HttpGet]
        public List<Talla> ObtenerTallas()
        {
            // Devuelve la lista de todas las tallas
            return _tallaStore.ObtenerTodas();
        }

        [HttpGet]
        public IHttpActionResult ObtenerTalla(int id)
        {
            try
            {
                // Intenta obtener una bodega por su ID
                Talla talla = _tallaStore.ObtenerPorID(id);

                if (talla == null)
                    // Si no se encuentra la talla, devuelve una respuesta NotFound
                    return NotFound();

                // Si se encuentra la talla, devuelve una respuesta Ok con la bodega
                return Ok(talla);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        // post
        [HttpPost]
        public IHttpActionResult AgregarTalla([FromBody] Talla nuevaTalla)
        {
            try
            {
                // Agrega una nueva bodega
                _tallaStore.AgregarTalla(nuevaTalla);

                // Obtiene la lista actualizada de tallas
                List<Talla> talla = ObtenerTallas();

                // Devuelve una respuesta Ok con la lista de tallas
                return Ok(talla);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        // actualizar
        [HttpPut]
        public IHttpActionResult ActualizarTalla(int id, [FromBody] Talla tallaActualizada)
        {
            try
            {
                // Intenta obtener la bodega existente por su ID
                Talla tallaExistente = _tallaStore.ObtenerPorID(id);

                if (tallaExistente == null)
                    // Si no se encuentra la bodega, devuelve una respuesta NotFound
                    return NotFound();

                // Actualiza los campos de la bodega existente con los datos proporcionados
                tallaExistente.NUM_TALLA = tallaActualizada.NUM_TALLA;
                // Obtiene la lista actualizada de tallas
                List<Talla> tallas = ObtenerTallas();

                // Devuelve una respuesta Ok con la lista de tallas
                return Ok(tallas);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        // borrar
        [HttpDelete]
        public IHttpActionResult EliminarTalla(int id)
        {
            try
            {
                // Intenta obtener la bodega existente por su ID
                Talla tallaExistente = _tallaStore.ObtenerPorID(id);

                if (tallaExistente == null)
                    // Si no se encuentra la bodega, devuelve una respuesta NotFound
                    return NotFound();

                // Elimina la bodega de la lista
                _tallaStore.BorrarTalla(id);

                // Obtiene la lista actualizada de bodegas
                List<Talla> talla = _tallaStore.ObtenerTodas();

                // Devuelve una respuesta Ok con la lista de bodegas
                return Ok(talla);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }


    }
}