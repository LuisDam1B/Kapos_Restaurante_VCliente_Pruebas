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
        private static readonly tema6bdluisEntitiesPruebas _contexto;

        static BDService()
        {
            _contexto = new tema6bdluisEntitiesPruebas();
            _contexto.CLIENTES.Load();
            _contexto.PEDIDOS.Load();

        }

        public static ObservableCollection<CLIENTES> getClientes()
        {
            return _contexto.CLIENTES.Local;
        }

        public static ObservableCollection<PEDIDOS> getPedidos()
        {
            return _contexto.PEDIDOS.Local;
        }
    }
}
