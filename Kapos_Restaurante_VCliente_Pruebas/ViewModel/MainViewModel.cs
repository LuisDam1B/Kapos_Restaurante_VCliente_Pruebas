using Kapos_Restaurante_VCliente_Pruebas.Model;
using Kapos_Restaurante_VCliente_Pruebas.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Kapos_Restaurante_VCliente_Pruebas.ViewModel
{
    class MainViewModel :INotifyPropertyChanged
    {
        //Clase que sirve de modelo de datos para la vista MainWindows
        public event PropertyChangedEventHandler PropertyChanged;

        public CollectionViewSource listaElementos { get; set; }

        public ELEMENTOS elementoSeleccionado { get; set; }
        

        //lista para ir añadiendo los elementos seleccionados.
        public ObservableCollection<ELEMENTOS> elementosSeleccionados { get; set; }

        public int NumElementosSeleccionados
        {
            get { return elementosSeleccionados.Count; }
        }

        public MainViewModel()
        {
            listaElementos = new CollectionViewSource
            {
                Source = BDService.getElementos()
            };

            elementosSeleccionados = new ObservableCollection<ELEMENTOS>();
        }

       

        public bool Añadir_CanExecute()
        {
            return (elementoSeleccionado != null);
        }

        public bool Cancelar_CanExecute()
        {
            return (elementosSeleccionados.Count > 0);
        }

        public void Añadir_Executed(Object elemento)
        {
           
           elementosSeleccionados.Add((ELEMENTOS)elemento);
           
        }

        public bool Validar_CanExecute()
        {
            return (elementosSeleccionados.Count > 0);
        }

        public void Validar_Executed()
        {
            foreach (var item in elementosSeleccionados)
            {
                Console.WriteLine(item);
            }
        }


    }
}
