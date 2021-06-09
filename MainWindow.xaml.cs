using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BuscadorIndex
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Busqueda busqueda;
        Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            string[] drives = Environment.GetLogicalDrives();
            foreach (var item in drives)
            {
                DiscosCombo.Items.Add(item);
            }
            DiscosCombo.SelectedIndex = 0;

         
        }

        private async void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            DateTime inicio = DateTime.Now;
            List<ResultadoBusqueda> lista_resultados = new List<ResultadoBusqueda>();
            StatusLabel.Visibility = Visibility.Visible;
            ListaBusqueda.ItemsSource = null;
            ListaBusqueda.Items.Clear();
            BuscarBoton.IsEnabled = false;
            lista_resultados.AddRange(await busqueda.ExBusqueda(DiscosCombo.SelectedItem.ToString(), BuscarTexto.Text));
            BuscarBoton.IsEnabled = true;
            ListaBusqueda.ItemsSource = lista_resultados;
            StatusLabel.Visibility = Visibility.Hidden;
            DateTime fin = DateTime.Now;
            TiempoLabel.Content = (fin - inicio).ToString();
           
        }

      

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BuscarBoton.IsEnabled = false;
            busqueda = new Busqueda { result = new List<ResultadoBusqueda>() };

            await Task.Run(()=> { busqueda.CargarIndices(); });
            BuscarBoton.IsEnabled = true;
            timer = new Timer(300000);
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            busqueda.Dispose();
           
            busqueda = new Busqueda { result = new List<ResultadoBusqueda>() };
            
            ContenidoIndexado c = new ContenidoIndexado();
            await c.Indexar();
            await Task.Run(() => { busqueda.CargarIndices(); });
           
        }
    }
}
