using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Endpoint.Entities
{
    public class BodegaStore
    {
        private static List<Bodega> _bodegas = new List<Bodega>();

        static BodegaStore()
        {
            // Agregar bodegas por defecto si lo deseas
            _bodegas.Add(new Bodega { ID_BODEGA = 1, NOMBRE_BODEGA = "Bodega 1", ID_PRODUCTO = 1, DIRECCION = "Dirección 1" });
            _bodegas.Add(new Bodega { ID_BODEGA = 2, NOMBRE_BODEGA = "Bodega 2", ID_PRODUCTO = 2, DIRECCION = "Dirección 2" });
            _bodegas.Add(new Bodega { ID_BODEGA = 3, NOMBRE_BODEGA = "Bodega 3", ID_PRODUCTO = 3, DIRECCION = "Dirección 3" });
        }

        // Método que retorna todas las bodegas
        public List<Bodega> ObtenerTodas()
        {
            return _bodegas;
        }

        // Método para agregar una nueva bodega
     
        public void AgregarBodega(Bodega nuevaBodega)
        {
            // Asegúrate de asignar un ID único a la nueva bodega
            nuevaBodega.ID_BODEGA = _bodegas.Count + 1;
            _bodegas.Add(nuevaBodega);
        }

        // Método que busca y retorna una bodega por su ID
        public Bodega ObtenerPorID(int id)
        {
            return _bodegas.FirstOrDefault(b => b.ID_BODEGA == id);
        }

        // Método para borrar una bodega por su ID
        public void BorrarBodega(int id)
        {
            Bodega bodegaExistente = _bodegas.FirstOrDefault(b => b.ID_BODEGA == id);
            if (bodegaExistente != null)
            {
                _bodegas.Remove(bodegaExistente);
            }
        }

        // Método para actualizar los datos de una bodega por su ID
        public void ActualizarBodega(int id, Bodega bodegaActualizada)
        {
            Bodega bodegaExistente = _bodegas.FirstOrDefault(b => b.ID_BODEGA == id);
            if (bodegaExistente != null)
            {
                bodegaExistente.NOMBRE_BODEGA = bodegaActualizada.NOMBRE_BODEGA;
                bodegaExistente.ID_PRODUCTO = bodegaActualizada.ID_PRODUCTO;
                bodegaExistente.DIRECCION = bodegaActualizada.DIRECCION;
            }
        }
    }
}
