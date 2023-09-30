using System;
using System.Collections.Generic;
using System.Web.Http;

public class ColorsController : ApiController
{
    private DataStore _dataStore = new DataStore();

    [HttpGet]
    public List<Color> ObtenerColores()
    {
        // Devuelve la lista de todos los colores
        return _dataStore.ObtenerTodos();
    }

    [HttpGet]
    public IHttpActionResult ObtenerColor(int id)
    {
        try
        {
            // Intenta obtener un color por su ID
            Color color = _dataStore.ObtenerPorID(id);

            if (color == null)
                // Si no se encuentra el color, devuelve una respuesta NotFound
                return NotFound();

            // Si se encuentra el color, devuelve una respuesta Ok con el color
            return Ok(color);
        }
        catch (Exception ex)
        {
            // Si ocurre un error, devuelve una respuesta InternalServerError con el error
            return InternalServerError(ex);
        }
    }

    [HttpPost]
    public IHttpActionResult AgregarColor([FromBody] Color nuevoColor)
    {
        try
        {
            // Agrega un nuevo color a la lista
            DataStore.AgregarColor(nuevoColor);

            // Obtiene la lista actualizada de colores
            List<Color> colores = ObtenerColores();

            // Devuelve una respuesta Ok con la lista de colores
            return Ok(colores);
        }
        catch (Exception ex)
        {
            // Si ocurre un error, devuelve una respuesta InternalServerError con el error
            return InternalServerError(ex);
        }
    }

    [HttpPut]
    public IHttpActionResult ActualizarColor(int id, [FromBody] Color colorActualizado)
    {
        try
        {
            // Intenta obtener el color existente por su ID
            Color colorExistente = _dataStore.ObtenerPorID(id);

            if (colorExistente == null)
                // Si no se encuentra el color, devuelve una respuesta NotFound
                return NotFound();

            // Actualiza los campos del color existente con los datos proporcionados
            colorExistente.NOMBRE_COLOR = colorActualizado.NOMBRE_COLOR;

            // Obtiene la lista actualizada de colores
            List<Color> colores = ObtenerColores();

            // Devuelve una respuesta Ok con la lista de colores
            return Ok(colores);
        }
        catch (Exception ex)
        {
            // Si ocurre un error, devuelve una respuesta InternalServerError con el error
            return InternalServerError(ex);
        }
    }

    [HttpDelete]
    public IHttpActionResult EliminarColor(int id)
    {
        try
        {
            // Intenta obtener el color existente por su ID
            Color colorExistente = _dataStore.ObtenerPorID(id);

            if (colorExistente == null)
                // Si no se encuentra el color, devuelve una respuesta NotFound
                return NotFound();

            // Elimina el color de la lista
            _dataStore.BorrarColor(id);

            // Obtiene la lista actualizada de colores
            List<Color> colores = _dataStore.ObtenerTodos();

            // Devuelve una respuesta Ok con la lista de colores
            return Ok(colores);
        }
        catch (Exception ex)
        {
            // Si ocurre un error, devuelve una respuesta InternalServerError con el error
            return InternalServerError(ex);
        }
    }
}