using System.Collections.Generic;
using System.Linq;

public class DataStore
{
    private static List<Color> _colores = new List<Color>();

    static DataStore()
    {
        // Agregar colores por defecto si lo deseas
        _colores.Add(new Color { ID_COLOR = 1, NOMBRE_COLOR = "Rojo" });
        _colores.Add(new Color { ID_COLOR = 2, NOMBRE_COLOR = "Verde" });
        _colores.Add(new Color { ID_COLOR = 3, NOMBRE_COLOR = "Azul" });
    }

    // Método que retorna todos los colores
    public List<Color> ObtenerTodos()
    {
        return _colores;
    }

    // Método para agregar un nuevo color a la lista
    public static void AgregarColor(Color nuevoColor)
    {
        // Asegúrate de asignar un ID único al nuevo color
        nuevoColor.ID_COLOR = _colores.Count + 1;
        _colores.Add(nuevoColor);
    }

    // Método que busca y retorna un color por su ID
    public Color ObtenerPorID(int id)
    {
        return _colores.FirstOrDefault(c => c.ID_COLOR == id);
    }

    // Método para borrar un color por su ID
    public void BorrarColor(int id)
    {
        Color colorExistente = _colores.FirstOrDefault(c => c.ID_COLOR == id);
        if (colorExistente != null)
        {
            _colores.Remove(colorExistente);
        }
    }

    // Método para actualizar el nombre de un color por su ID
    public void ActualizarColor(int id, Color colorActualizado)
    {
        Color colorExistente = _colores.FirstOrDefault(c => c.ID_COLOR == id);
        if (colorExistente != null)
        {
            colorExistente.NOMBRE_COLOR = colorActualizado.NOMBRE_COLOR;
        }
    }
}
