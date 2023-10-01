using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class MaterialController : ApiController
    {
        private EntityStore<Material> _materialStore;

        public MaterialController()
        {
            _materialStore = new EntityStore<Material>(m => m.ID);
        }

        [HttpGet]
        public IHttpActionResult ObtenerMateriales()
        {
            try
            {
                List<Material> materiales = _materialStore.ObtenerTodo();
                return Ok(materiales);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerMaterial(int id)
        {
            try
            {
                Material material = _materialStore.ObtenerPorId(id);

                if (material == null)
                    return NotFound();

                return Ok(material);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarMaterial([FromBody] Material nuevoMaterial)
        {
            try
            {
                _materialStore.Agregar(nuevoMaterial);
                List<Material> materiales = _materialStore.ObtenerTodo();
                return Ok(materiales);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarMaterial(int id, [FromBody] Material materialActualizado)
        {
            try
            {
                _materialStore.Actualizar(id, materialActualizado);
                List<Material> materiales = _materialStore.ObtenerTodo();
                return Ok(materiales);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarMaterial(int id)
        {
            try
            {
                _materialStore.Eliminar(id);
                List<Material> materiales = _materialStore.ObtenerTodo();
                return Ok(materiales);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
