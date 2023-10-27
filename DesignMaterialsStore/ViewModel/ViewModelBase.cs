using DesignMaterialsStore.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMaterialsStore.ViewModel
{
    /// <summary>
    /// Base class for all the ViewModels for invoking the property OnPropertyChanged
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        //Fields
        public event PropertyChangedEventHandler PropertyChanged;

        //Methods
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }//end class
}//end namespace
