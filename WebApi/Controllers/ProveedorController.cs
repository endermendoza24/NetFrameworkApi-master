using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class ProveedorController : ApiController
    {
        private EntityStore<Proveedor> _proveedorStore;

        public ProveedorController()
        {
            _proveedorStore = new EntityStore<Proveedor>(p => p.ID);
        }

        [HttpGet]
        public IHttpActionResult ObtenerProveedores()
        {
            try
            {
                List<Proveedor> proveedores = _proveedorStore.ObtenerTodo();
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerProveedor(int id)
        {
            try
            {
                Proveedor proveedor = _proveedorStore.ObtenerPorId(id);

                if (proveedor == null)
                    return NotFound();

                return Ok(proveedor);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarProveedor([FromBody] Proveedor nuevoProveedor)
        {
            try
            {
                _proveedorStore.Agregar(nuevoProveedor);
                List<Proveedor> proveedores = _proveedorStore.ObtenerTodo();
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarProveedor(int id, [FromBody] Proveedor proveedorActualizado)
        {
            try
            {
                _proveedorStore.Actualizar(id, proveedorActualizado);
                List<Proveedor> proveedores = _proveedorStore.ObtenerTodo();
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarProveedor(int id)
        {
            try
            {
                _proveedorStore.Eliminar(id);
                List<Proveedor> proveedores = _proveedorStore.ObtenerTodo();
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
