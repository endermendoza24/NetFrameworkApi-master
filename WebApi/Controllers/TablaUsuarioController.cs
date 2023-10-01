using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class TablaUsuarioController : ApiController
    {
        private EntityStore<TablaUsuario> _usuarioStore;

        public TablaUsuarioController()
        {
            _usuarioStore = new EntityStore<TablaUsuario>(u => u.ID);
        }

        [HttpGet]
        public IHttpActionResult ObtenerUsuarios()
        {
            try
            {
                List<TablaUsuario> usuarios = _usuarioStore.ObtenerTodo();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerUsuario(int id)
        {
            try
            {
                TablaUsuario usuario = _usuarioStore.ObtenerPorId(id);

                if (usuario == null)
                    return NotFound();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarUsuario([FromBody] TablaUsuario nuevoUsuario)
        {
            try
            {
                _usuarioStore.Agregar(nuevoUsuario);
                List<TablaUsuario> usuarios = _usuarioStore.ObtenerTodo();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarUsuario(int id, [FromBody] TablaUsuario usuarioActualizado)
        {
            try
            {
                _usuarioStore.Actualizar(id, usuarioActualizado);
                List<TablaUsuario> usuarios = _usuarioStore.ObtenerTodo();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarUsuario(int id)
        {
            try
            {
                _usuarioStore.Eliminar(id);
                List<TablaUsuario> usuarios = _usuarioStore.ObtenerTodo();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
