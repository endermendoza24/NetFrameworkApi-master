using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class BodegaController : ApiController
    {
        private EntityStore<Bodega> _bodegaStore;

        public BodegaController()
        {
            _bodegaStore = new EntityStore<Bodega>(b => b.ID);
        }

        [HttpGet]
        public IHttpActionResult ObtenerBodegas()
        {
            try
            {
                List<Bodega> bodegas = _bodegaStore.ObtenerTodo();
                return Ok(bodegas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerBodega(int id)
        {
            try
            {
                Bodega bodega = _bodegaStore.ObtenerPorId(id);

                if (bodega == null)
                    return NotFound();

                return Ok(bodega);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarBodega([FromBody] Bodega nuevaBodega)
        {
            try
            {
                _bodegaStore.Agregar(nuevaBodega);
                List<Bodega> bodegas = _bodegaStore.ObtenerTodo();
                return Ok(bodegas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarBodega(int id, [FromBody] Bodega bodegaActualizada)
        {
            try
            {
                _bodegaStore.Actualizar(id, bodegaActualizada);
                List<Bodega> bodegas = _bodegaStore.ObtenerTodo();
                return Ok(bodegas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarBodega(int id)
        {
            try
            {
                _bodegaStore.Eliminar(id);
                List<Bodega> bodegas = _bodegaStore.ObtenerTodo();
                return Ok(bodegas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
