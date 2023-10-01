using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Application.Endpoint
{
    public class EntityStore<T> where T : class
    {
        private static List<T> _entidades = new List<T>();
        private Func<T, int> _obtenerIdFunc;
        private static int _siguienteId = 1;

        public EntityStore(Func<T, int> obtenerIdFunc)
        {
            _obtenerIdFunc = obtenerIdFunc;
            // Inicializa _siguienteId solo si es igual a cero
            if (_siguienteId == 0)
            {
                _siguienteId = _entidades.Count + 1;
            }
        }

        public EntityStore()
        {
        }

        public List<T> ObtenerTodo()
        {
            return _entidades;
        }

        public void Agregar(T entidad)
        {
            int id = _siguienteId++;
            typeof(T).GetProperty("ID")?.SetValue(entidad, id);
            _entidades.Add(entidad);
        }

        public T ObtenerPorId(int id)
        {
            return _entidades.FirstOrDefault(e => _obtenerIdFunc(e) == id);
        }

        public void Eliminar(int id)
        {
            T entidad = _entidades.FirstOrDefault(e => _obtenerIdFunc(e) == id);
            if (entidad != null)
            {
                _entidades.Remove(entidad);
            }
        }

        public void Actualizar(int id, T entidadActualizada)
        {
            T entidad = _entidades.FirstOrDefault(e => _obtenerIdFunc(e) == id);
            if (entidad != null)
            {
                // Copia los valores de las propiedades relevantes de entidadActualizada a entidad
                PropertyInfo[] propiedades = typeof(T).GetProperties();
                foreach (PropertyInfo property in propiedades)
                {
                    if (property.Name != "ID") // Evita modificar la property "ID"
                    {
                        object nuevoValor = property.GetValue(entidadActualizada);
                        if (nuevoValor != null)
                        {
                            property.SetValue(entidad, nuevoValor);
                        }
                    }
                }
            }
        }
    }
}
