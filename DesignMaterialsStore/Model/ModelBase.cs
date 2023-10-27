using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMaterialsStore.Model
{
    /// <summary>
    /// Base class for all the models for invoking the property OnPropertyChanged
    /// </summary>
    public class ModelBase : INotifyPropertyChanged
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
