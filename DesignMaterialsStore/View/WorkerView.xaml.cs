using DesignMaterialsStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logique d'interaction pour WorkerView.xaml
    /// </summary>
    public partial class WorkerView : UserControl
    {
        //Constructor
        public WorkerView()
        {
            InitializeComponent();
        }

        //Method that executes when the user double click on the datagrid
        private void DataGridWorker_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is WorkerViewModel workerViewModel && workerViewModel.SelectedWorker != null)
            {
                //Open the view to edit the worker
                EditWorkerViewModel ewVM = new EditWorkerViewModel(workerViewModel.SelectedWorker);
                EditWorkerView ewV = new EditWorkerView();
                ewV.DataContext = ewVM;
                ewV.Show();

                //if the edit window is closed, the list of employees is automatically updated
                ewV.IsVisibleChanged += (s, ev) =>
                {
                    if(ewV.IsVisible == false)
                    {
                        this.DataContext = new WorkerViewModel();
                    }
                };

            }
        }

    }//end class
}//end namespace
