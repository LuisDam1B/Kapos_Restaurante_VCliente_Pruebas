using Kapos_Restaurante_VCliente_Pruebas.Model;
using Kapos_Restaurante_VCliente_Pruebas.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Kapos_Restaurante_VCliente_Pruebas.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        //Clase que sirve de modelo de datos para la vista MainWindows
        public event PropertyChangedEventHandler PropertyChanged;

        public CollectionViewSource listaPedidos { get; set; }

        public PEDIDOS pedidoSeleccionado { get; set; }

        //lista para ir añadiendo los elementos seleccionados.
        public List<PEDIDO> pedidosSeleccionados { get; set; }

        public MainViewModel()
        {
            listaPedidos = new CollectionViewSource
            {
                Source = BDService.getPedidos()
            };
        }
        
        public bool Añadir_CanExecute()
        {
            return (pedidoSeleccionado != null);
        }


    }
}
