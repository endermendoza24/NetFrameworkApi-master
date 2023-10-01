using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class ColorsController : ApiController
    {
        private EntityStore<Color> _colorStore;

        public ColorsController()
        {
            _colorStore = new EntityStore<Color>(c => c.ID);
        }

        [HttpGet]
        public IHttpActionResult ObtenerColores()
        {
            try
            {
                List<Color> colores = _colorStore.ObtenerTodo();
                return Ok(colores);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerColor(int id)
        {
            try
            {
                Color color = _colorStore.ObtenerPorId(id);

                if (color == null)
                    return NotFound();

                return Ok(color);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarColor([FromBody] Color nuevoColor)
        {
            try
            {
                _colorStore.Agregar(nuevoColor);
                List<Color> colores = _colorStore.ObtenerTodo();
                return Ok(colores);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarColor(int id, [FromBody] Color colorActualizado)
        {
            try
            {
                _colorStore.Actualizar(id, colorActualizado);
                List<Color> colores = _colorStore.ObtenerTodo();
                return Ok(colores);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarColor(int id)
        {
            try
            {
                _colorStore.Eliminar(id);
                List<Color> colores = _colorStore.ObtenerTodo();
                return Ok(colores);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
