using DesignMaterialsStore.ViewModel;
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

namespace DesignMaterialsStore.View
{
    /// <summary>
    /// Logique d'interaction pour ClientView.xaml
    /// </summary>
    public partial class ClientView : UserControl
    {
        //Constructor
        public ClientView()
        {
            InitializeComponent();
        }

        //Method that executes when the user double click on the datagrid
        private void DataGridClient_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is ClientViewModel clientViewModel && clientViewModel.SelectedClient != null)
            {
                //Open the view to edit the client
                EditClientViewModel ewVM = new EditClientViewModel(clientViewModel.SelectedClient);
                EditClientView ewV = new EditClientView();
                ewV.DataContext = ewVM;
                ewV.Show();

                //if the edit window is closed, the list of clients is automatically updated
                ewV.IsVisibleChanged += (s, ev) =>
                {
                    if (ewV.IsVisible == false)
                    {
                        this.DataContext = new ClientViewModel();
                    }
                };

            }
        }

    }//end class
}//end namespace
