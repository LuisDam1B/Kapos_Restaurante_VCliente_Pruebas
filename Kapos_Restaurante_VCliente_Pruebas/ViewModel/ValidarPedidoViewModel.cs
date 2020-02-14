using Kapos_Restaurante_VCliente_Pruebas.Model;
using Kapos_Restaurante_VCliente_Pruebas.Service;
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

        public double PrecioTotal {

            get { return CalcularPrecio(); }
            
        }

        public ValidarPedidoViewModel(Object objeto)
        {
            ListaElementosPedidos = (ObservableCollection<ELEMENTOS>)objeto;
        }

        public double CalcularPrecio()
        {
            double precio = 0;

            foreach (ELEMENTOS elemento in ListaElementosPedidos)
            {
                
                int numElementos = 0;
                numElementos = BDService.ObtenerNumElementos(elemento.IdElemento);
                precio += numElementos * elemento.Precio;
            }

            return precio;
        }

        public void abrirValidacionManualUsuario()
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory().ToString() /*+ "\\NombreManual.chm"*/);
        }

    }
}
