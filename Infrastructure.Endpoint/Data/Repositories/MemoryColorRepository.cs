//using System.Collections.Generic;
//using System.Linq;

//public class MemoryColorRepository
//{
//    private List<Color> _colores = new List<Color>();

//    public MemoryColorRepository()
//    {
//        // Puedes agregar colores predeterminados aquí si lo deseas
//        _colores.Add(new Color { ID_COLOR = 1, NOMBRE_COLOR = "Rojo" });
//        _colores.Add(new Color { ID_COLOR = 2, NOMBRE_COLOR = "Verde" });
//        _colores.Add(new Color { ID_COLOR = 3, NOMBRE_COLOR = "Azul" });
//    }

//    public void AgregarColor(Color nuevoColor)
//    {
//        // Asegúrate de asignar un ID único al nuevo color
//        nuevoColor.ID_COLOR = _colores.Count + 1;
//        _colores.Add(nuevoColor);
//    }

//    public List<Color> ObtenerTodos()
//    {
//        return _colores;
//    }

//    public Color ObtenerPorID(int id)
//    {
//        return _colores.FirstOrDefault(c => c.ID_COLOR == id);
//    }
//}
