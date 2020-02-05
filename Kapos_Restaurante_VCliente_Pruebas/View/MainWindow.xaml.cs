using Kapos_Restaurante_VCliente_Pruebas.ViewModel;
using Kapos_Restaurante_VCliente_Pruebas.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kapos_Restaurante_VCliente_Pruebas;
using Kapos_Restaurante_VCliente_Pruebas.View;

namespace Kapos_Restaurante_VCliente_Pruebas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            this.DataContext = new MainViewModel();
            InitializeComponent();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listaPedidos_ListView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Categoria");
            view.GroupDescriptions.Add(groupDescription);
            //prievb
            
        }

        //Commads

        private void AñadirCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (this.DataContext as ViewModel.MainViewModel).Añadir_CanExecute();

        }

        private void AñadirCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            (this.DataContext as ViewModel.MainViewModel).Añadir_Executed();
        }

        private void CancelarCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {



        }
        private void CancelarCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            e.CanExecute = (this.DataContext as ViewModel.MainViewModel).Cancelar_CanExecute();
        }

        private void ValidarCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ValidarPedido validarPedidoView = new View.ValidarPedido((this.DataContext as ViewModel.MainViewModel).elementosSeleccionados);
            validarPedidoView.Owner = this;
            validarPedidoView.Show();

        }

        private void ValidarCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            e.CanExecute = (this.DataContext as ViewModel.MainViewModel).Validar_CanExecute();
        }


    }
}
