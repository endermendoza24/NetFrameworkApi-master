

public class MemoryColorRepository
{
    private List<Color> _colores = new List<Color>();

    public MemoryColorRepository()
    {
        // Puedes agregar colores predeterminados aquí si lo deseas
        _colores.Add(new Color { ID_COLOR = 1, NOMBRE_COLOR = "Rojo" });
        _colores.Add(new Color { ID_COLOR = 2, NOMBRE_COLOR = "Verde" });
        _colores.Add(new Color { ID_COLOR = 3, NOMBRE_COLOR = "Azul" });
    }

    public List<Color> ObtenerTodos()
    {
        return _colores;
    }

    public Color ObtenerPorID(int id)
    {
        return _colores.FirstOrDefault(c => c.ID_COLOR == id);
    }

    public void AgregarColor(Color nuevoColor)
    {
        // Asigna un ID único (simulado)
        nuevoColor.ID_COLOR = _colores.Max(c => c.ID_COLOR) + 1;
        _colores.Add(nuevoColor);
    }

    // Puedes añadir más métodos según lo que necesites
}
