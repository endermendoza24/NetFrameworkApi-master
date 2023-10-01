using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    public class TallaStore
    {
        private static List<Talla> _tallas = new List<Talla>();

        static TallaStore()
        {
            _tallas.Add(new Talla { ID_TALLA = 1, NUM_TALLA = "30" });
            _tallas.Add(new Talla { ID_TALLA = 2, NUM_TALLA = "32" });
            _tallas.Add(new Talla { ID_TALLA = 3, NUM_TALLA = "34" });
        }

        public List<Talla> ObtenerTodas()
        {
            return _tallas;
        }

        public void AgregarTalla(Talla nuevaTalla)
        {
            nuevaTalla.ID_TALLA = _tallas.Count + 1;
            _tallas.Add(nuevaTalla);
        }

        public Talla ObtenerPorID(int id)
        {
            return _tallas.FirstOrDefault(t => t.ID_TALLA == id);
        }

        public void BorrarTalla(int id)
        {
            Talla tallaExistente = _tallas.FirstOrDefault(t => t.ID_TALLA == id);
            if (tallaExistente != null)
            {
                _tallas.Remove(tallaExistente);
            }
        }

        public void ActualizarTalla(int id, Talla tallaActualizada)
        {
            Talla tallaExistente = _tallas.FirstOrDefault(t => t.ID_TALLA == id);
            if (tallaExistente != null)
            {
                tallaExistente.NUM_TALLA = tallaActualizada.NUM_TALLA;
            }
        }
    }
}
