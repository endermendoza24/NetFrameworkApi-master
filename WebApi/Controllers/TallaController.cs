using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class TallaController : ApiController
    {
        public TallaController()
        {
            _tallaStore = new EntityStore<Talla>(t => t.ID);
        }
        private EntityStore<Talla> _tallaStore = new EntityStore<Talla>();

        [HttpGet]
        public IHttpActionResult ObtenerTallas()
        {
            try
            {
                // Obtiene la lista de todas las tallas
                List<Talla> tallas = _tallaStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de tallas
                return Ok(tallas);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerTalla(int id)
        {
            try
            {
                // Intenta obtener una talla por su ID
                Talla talla = _tallaStore.ObtenerPorId(id);

                if (talla == null)
                    // Si no se encuentra la talla, devuelve una respuesta NotFound
                    return NotFound();

                // Si se encuentra la talla, devuelve una respuesta Ok con la talla
                return Ok(talla);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarTalla([FromBody] Talla nuevaTalla)
        {
            try
            {
                // Agrega una nueva talla
                _tallaStore.Agregar(nuevaTalla);

                // Obtiene la lista actualizada de tallas
                List<Talla> tallas = _tallaStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de tallas
                return Ok(tallas);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarTalla(int id, [FromBody] Talla tallaActualizada)
        {
            try
            {
                // Intenta actualizar la talla por su ID
                _tallaStore.Actualizar(id, tallaActualizada);

                // Obtiene la lista actualizada de tallas
                List<Talla> tallas = _tallaStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de tallas
                return Ok(tallas);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarTalla(int id)
        {
            try
            {
                // Intenta eliminar la talla por su ID
                _tallaStore.Eliminar(id);

                // Obtiene la lista actualizada de tallas
                List<Talla> tallas = _tallaStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de tallas
                return Ok(tallas);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }
    }
}
