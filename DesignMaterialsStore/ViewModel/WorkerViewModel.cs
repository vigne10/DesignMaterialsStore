using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignMaterialsStore.Model;
using System.Windows.Input;
using DesignMaterialsStore.View;
using System.Windows;
using System.Windows.Forms;

namespace DesignMaterialsStore.ViewModel
{
    public class WorkerViewModel : ViewModelBase
    {

        //Fields
        private WorkerDAO wDAO;
        private ObservableCollection<Worker> _workerCollection;
        private Worker _selectedWorker;

        //Commands
        public ICommand AddWorkerCommand { get; }

        //Constructor
        public WorkerViewModel()
        {
            wDAO = DAOFactory.getWorkerDAO();
            WorkerCollection = wDAO.findAll();
            SelectedWorker = new Worker();
            AddWorkerCommand = new ViewModelCommand(ExecuteAddWorkerCommand);
        }

        //Properties
        public ObservableCollection<Worker> WorkerCollection
        {
            get
            {
                return _workerCollection;
            }
            set
            {
                _workerCollection = value;
                OnPropertyChanged(nameof(WorkerCollection));
            }
        }

        public Worker SelectedWorker
        {
            get
            {
                return _selectedWorker;
            }
            set
            {
                _selectedWorker = value;
                OnPropertyChanged(nameof(SelectedWorker));
            }
        }

        //Methods
        private void ExecuteAddWorkerCommand(object obj)
        {
            AddWorkerView addView = new AddWorkerView(WorkerCollection);
            addView.Show();
        }

    }//end class
}//end namespace
