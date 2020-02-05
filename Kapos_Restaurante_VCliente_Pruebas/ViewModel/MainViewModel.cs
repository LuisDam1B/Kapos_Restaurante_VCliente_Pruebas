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
    class MainViewModel : INotifyPropertyChanged
    {
        //Clase que sirve de modelo de datos para la vista MainWindows
        public event PropertyChangedEventHandler PropertyChanged;

        public CollectionViewSource listaElementos { get; set; }

        public ELEMENTOS ElementoSeleccionado { get; set; }

        public int TotalElementosSeleccionados { get; set; }

        //lista para ir añadiendo los elementos seleccionados.
        public ObservableCollection<ELEMENTOS> elementosSeleccionados { get; set; }
        public FACTURA ComandaPedidoActual { get; set; }

        public COMANDAS PedidoActual { get; set; }

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



            PedidoActual = new COMANDAS();
            PedidoActual.FechaComanda = DateTime.Now;
            PedidoActual.Servida = 0;

            ComandaPedidoActual = new FACTURA();
            ComandaPedidoActual.IdComanda = PedidoActual.IdComanda;
            ComandaPedidoActual.CantidadElementos = 0;
            TotalElementosSeleccionados = 0;

            elementosSeleccionados = new ObservableCollection<ELEMENTOS>();
        }



        public bool Añadir_CanExecute()
        {
            return (ElementoSeleccionado != null);
        }

        public bool Cancelar_CanExecute()
        {
            return (elementosSeleccionados.Count > 0);
        }

        public void Añadir_Executed()
        {
            if (elementosSeleccionados.Count >= 1)
                foreach (ELEMENTOS elem in elementosSeleccionados)
                {
                    if (ElementoSeleccionado != null)
                    {
                        if (ElementoSeleccionado.Equals(elem))
                        {
                            ComandaPedidoActual.CantidadElementos++;
                            BDService.ActualizarBbdd();
                        }
                        else
                        {
                            elementosSeleccionados.Add(ElementoSeleccionado);
                            ComandaPedidoActual.IdElemento = ElementoSeleccionado.IdElemento;
                            ComandaPedidoActual.CantidadElementos = 1;
                            BDService.AddFactura(ComandaPedidoActual);
                        }
                    }
                }
            else
            {
                elementosSeleccionados.Add(ElementoSeleccionado);
            }
            TotalElementosSeleccionados++;
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
