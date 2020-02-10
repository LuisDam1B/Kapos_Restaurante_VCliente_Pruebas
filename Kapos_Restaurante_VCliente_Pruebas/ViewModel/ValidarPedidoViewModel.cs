using Kapos_Restaurante_VCliente_Pruebas.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapos_Restaurante_VCliente_Pruebas.ViewModel
{
    class ValidarPedidoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ELEMENTOS> ListaElementosPedidos { get; set; }
        public int CantidadElementoPedido { get; set; }

        public ValidarPedidoViewModel(Object objeto)
        {
            ListaElementosPedidos = (ObservableCollection<ELEMENTOS>)objeto;
        }


    }
}
