using DesignMaterialsStore.Model;
using DesignMaterialsStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace DesignMaterialsStore.View
{
    /// <summary>
    /// Logique d'interaction pour AddWorkerView.xaml
    /// </summary>
    public partial class AddWorkerView : Window
    {
        //Fields
        private AddWorkerViewModel viewModel;

        //Constructor
        public AddWorkerView(ObservableCollection<Worker> workers)
        {
            InitializeComponent();
            viewModel = new AddWorkerViewModel(workers);
            DataContext = viewModel;
        }

        //Methods
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }//end class
}//end namespace
