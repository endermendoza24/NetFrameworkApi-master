using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class EntityStore<T> where T : class
    {
        private List<T> _entities = new List<T>();

        public EntityStore()
        {
            // Puedes agregar elementos predeterminados si lo deseas
        }

        public List<T> GetAll()
        {
            return _entities;
        }

        public void Add(T entity)
        {
            // Asignar un ID único a la entidad si es necesario
            // Por ejemplo, puedes generar un ID único automáticamente.
            // entity.Id = GenerateUniqueId();
            _entities.Add(entity);
        }

        public T GetById(int id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }

        public void Delete(int id)
        {
            T entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

        public void Update(int id, T updatedEntity)
        {
            T entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                // Actualizar los campos relevantes de la entidad
                // entity.Propiedad = updatedEntity.Propiedad;
            }
        }
    }
}
