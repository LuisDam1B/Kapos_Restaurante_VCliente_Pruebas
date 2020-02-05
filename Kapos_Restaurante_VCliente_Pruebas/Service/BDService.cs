using Kapos_Restaurante_VCliente_Pruebas.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapos_Restaurante_VCliente_Pruebas.Service
{
    public static class BDService
    {
        private static readonly Tema_6Entities _contexto;

        static BDService()
        {
            _contexto = new Tema_6Entities();
            _contexto.CATEGORIAS.Load();
            _contexto.ELEMENTOS.Load();

        }

        public static ObservableCollection<CATEGORIAS> getCategorias()
        {
            return _contexto.CATEGORIAS.Local;
        }

        public static ObservableCollection<ELEMENTOS> getElementos()
        {
            return _contexto.ELEMENTOS.Local;
        }

        public static string getUrlImagen(int id)
        {
            var consulta = from n in _contexto.CATEGORIAS
                           where n.IdCategoria == id
                           select n.ImagenCategoriaURL;


            return consulta.First();     
        }

        public static string getNombre(int id)
        {
            var consulta = from n in _contexto.CATEGORIAS
                           where n.IdCategoria == id
                           select n.NombreCategoria;


            return consulta.First();
        }

        public static int AddFactura(FACTURA item)
        {
            _contexto.FACTURA.Add(item);
            return _contexto.SaveChanges();
        }


        //ESTE NO ESTÁ TERMINADO
        public static int ActualizarCantidadElementos(int idElemento)
        {
            var consulta = from f in _contexto.FACTURA
                           where f.IdElemento == idElemento
                           select f.CantidadElementos;

            int cantidad = consulta.First();

            return _contexto.SaveChanges();
        }


        public static int ActualizarBbdd()
        {
            return _contexto.SaveChanges();
        }
    }
}
