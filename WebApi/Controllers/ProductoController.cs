using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        private EntityStore<Producto> _productoStore;

        public ProductoController()
        {
            _productoStore = new EntityStore<Producto>(p => p.ID);
        }

        [HttpGet]
        public IHttpActionResult ObtenerProductos()
        {
            try
            {
                List<Producto> productos = _productoStore.ObtenerTodo();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerProducto(int id)
        {
            try
            {
                Producto producto = _productoStore.ObtenerPorId(id);

                if (producto == null)
                    return NotFound();

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarProducto([FromBody] Producto nuevoProducto)
        {
            try
            {
                _productoStore.Agregar(nuevoProducto);
                List<Producto> productos = _productoStore.ObtenerTodo();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarProducto(int id, [FromBody] Producto productoActualizado)
        {
            try
            {
                _productoStore.Actualizar(id, productoActualizado);
                List<Producto> productos = _productoStore.ObtenerTodo();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarProducto(int id)
        {
            try
            {
                _productoStore.Eliminar(id);
                List<Producto> productos = _productoStore.ObtenerTodo();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
