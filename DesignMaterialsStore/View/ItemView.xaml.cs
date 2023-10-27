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
    /// Logique d'interaction pour ItemView.xaml
    /// </summary>
    public partial class ItemView : UserControl
    {
        //Constructor
        public ItemView()
        {
            InitializeComponent();
        }

        //Methods

        //Method that executes when the user double click on the datagrid
        private void DataGridItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is ItemViewModel itemViewModel && itemViewModel.SelectedItem != null)
            {
                //Open the view to edit the item
                EditItemViewModel ewVM = new EditItemViewModel(itemViewModel.SelectedItem);
                EditItemView ewV = new EditItemView();
                ewV.DataContext = ewVM;
                ewV.Show();

                //if the edit window is closed, the list of items is automatically updated
                ewV.IsVisibleChanged += (s, ev) =>
                {
                    if (ewV.IsVisible == false)
                    {
                        this.DataContext = new ItemViewModel();
                    }
                };

            }
        }

    }//end class
}//end namespace
