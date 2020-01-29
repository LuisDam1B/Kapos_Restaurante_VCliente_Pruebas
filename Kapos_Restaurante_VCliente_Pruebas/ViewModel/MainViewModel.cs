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
        

        public CollectionViewSource listaElementos { get; set; }

        public ELEMENTOS elementoSeleccionado { get; set; }

        //lista para ir añadiendo los elementos seleccionados.
        public List<ELEMENTOS> elementosSeleccionados { get; set; }

        public MainViewModel()
        {
            listaElementos = new CollectionViewSource
            {
                Source = BDService.getElementos()
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Añadir_CanExecute()
        {
            return (elementoSeleccionado != null);
        }

        public bool Cancelar_CanExecute()
        {
            return (elementosSeleccionados != null);
        }

        public void Añadir_Executed()
        {
            elementosSeleccionados.Add(elementoSeleccionado);
        }

    }
}
