using System;
using System.Collections.Generic;
using System.Web.Http;
using Domain.Endpoint.Entities;

namespace WebApi.Controllers
{
    public class BodegaController : ApiController
    {
        private BodegaStore _bodegaStore = new BodegaStore();

        [HttpGet]
        public List<Bodega> ObtenerBodegas()
        {
            // Devuelve la lista de todas las bodegas
            return _bodegaStore.ObtenerTodas();
        }

        [HttpGet]
        public IHttpActionResult ObtenerBodega(int id)
        {
            try
            {
                // Intenta obtener una bodega por su ID
                Bodega bodega = _bodegaStore.ObtenerPorID(id);

                if (bodega == null)
                    // Si no se encuentra la bodega, devuelve una respuesta NotFound
                    return NotFound();

                // Si se encuentra la bodega, devuelve una respuesta Ok con la bodega
                return Ok(bodega);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarBodega([FromBody] Bodega nuevaBodega)
        {
            try
            {
                // Agrega una nueva bodega
                _bodegaStore.AgregarBodega(nuevaBodega);

                // Obtiene la lista actualizada de bodegas
                List<Bodega> bodegas = ObtenerBodegas();

                // Devuelve una respuesta Ok con la lista de bodegas
                return Ok(bodegas);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarBodega(int id, [FromBody] Bodega bodegaActualizada)
        {
            try
            {
                // Intenta obtener la bodega existente por su ID
                Bodega bodegaExistente = _bodegaStore.ObtenerPorID(id);

                if (bodegaExistente == null)
                    // Si no se encuentra la bodega, devuelve una respuesta NotFound
                    return NotFound();

                // Actualiza los campos de la bodega existente con los datos proporcionados
                bodegaExistente.NOMBRE_BODEGA = bodegaActualizada.NOMBRE_BODEGA;
                bodegaExistente.ID_PRODUCTO = bodegaActualizada.ID_PRODUCTO;
                bodegaExistente.DIRECCION = bodegaActualizada.DIRECCION;

                // Obtiene la lista actualizada de bodegas
                List<Bodega> bodegas = ObtenerBodegas();

                // Devuelve una respuesta Ok con la lista de bodegas
                return Ok(bodegas);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarBodega(int id)
        {
            try
            {
                // Intenta obtener la bodega existente por su ID
                Bodega bodegaExistente = _bodegaStore.ObtenerPorID(id);

                if (bodegaExistente == null)
                    // Si no se encuentra la bodega, devuelve una respuesta NotFound
                    return NotFound();

                // Elimina la bodega de la lista
                _bodegaStore.BorrarBodega(id);

                // Obtiene la lista actualizada de bodegas
                List<Bodega> bodegas = _bodegaStore.ObtenerTodas();

                // Devuelve una respuesta Ok con la lista de bodegas
                return Ok(bodegas);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }
    }
}
