using DAN_XLII_MilosPeric.Commands;
using DAN_XLII_MilosPeric.Service;
using DAN_XLII_MilosPeric.Utility;
using DAN_XLII_MilosPeric.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLII_MilosPeric.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow _main;
        DataBaseService _dataBaseService = new DataBaseService();
        List<vwLocation> LocationListFromDB = new List<vwLocation>();
        List<tblLocation> LocationListFromFile = new List<tblLocation>();


        public MainWindowViewModel(MainWindow mainOpen)
        {
            _main = mainOpen;
            WorkerList = _dataBaseService.GetAllWorkerRecords().ToList();
            LocationListFromDB = _dataBaseService.GetAllLocations();
            if (LocationListFromDB.Count == 0)
            {
                LocationListFromFile = LocationLoader.LoadLocations();
                _dataBaseService.AddLocationsToDataBase(LocationListFromFile);
            }
            foreach (var item in LocationListFromFile)
            {
                System.Diagnostics.Debug.WriteLine("Location: " + item.Address + item.City + item.Country);
            }
        }

        #region Properties
        private vwWorker _worker;
        public vwWorker Worker
        {
            get
            {
                return _worker;
            }
            set
            {
                _worker = value;
                OnPropertyChanged("Worker");
            }
        }

        private List<vwWorker> _workerList;
        public List<vwWorker> WorkerList
        {
            get
            {
                return _workerList;
            }
            set
            {
                _workerList = value;
                OnPropertyChanged("WorkerList");
            }
        }




        #endregion

        private ICommand _addNewWorker;
        public ICommand AddNewWorker
        {
            get
            {
                if (_addNewWorker == null)
                {
                    _addNewWorker = new RelayCommand(param => AddNewWorkerExecute(), param => CanAddNewWorkerExecute());
                }
                return _addNewWorker;
            }
        }

        private void AddNewWorkerExecute()
        {
            try
            {
                AddWorker addWorker = new AddWorker();
                addWorker.ShowDialog();
                if ((addWorker.DataContext as AddWorkerViewModel).IsUpdateWorker == true)
                {
                    WorkerList = _dataBaseService.GetAllWorkerRecords().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddNewWorkerExecute()
        {
            return true;
        }

        private ICommand _editWorker;
        public ICommand EditWorker
        {
            get
            {
                if (_editWorker == null)
                {
                    _editWorker = new RelayCommand(param => EditWorkerExecute(), param => CanEditWorkerExecute());
                }
                return _editWorker;
            }
        }

        private void EditWorkerExecute()
        {
            try
            {
                if (Worker != null)
                {
                    EditWorker editWorker = new EditWorker(Worker);
                    editWorker.ShowDialog();
                    WorkerList = _dataBaseService.GetAllWorkerRecords().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanEditWorkerExecute()
        {
            if (Worker == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand _deleteWorker;
        public ICommand DeleteWorker
        {
            get
            {
                if (_deleteWorker == null)
                {
                    _deleteWorker = new RelayCommand(param => DeleteWorkerExecute(), param => CanDeleteWorkerExecute());
                }
                return _deleteWorker;
            }
        }

        private void DeleteWorkerExecute()
        {
            try
            {
                if (Worker != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete employee record?", "Delete Record", MessageBoxButton.OKCancel);
                    switch (result)
                    {
                        case MessageBoxResult.OK:
                            int _workerID = _worker.WorkerID;
                            _dataBaseService.DeleteWorker(_workerID);
                            WorkerList = _dataBaseService.GetAllWorkerRecords().ToList();
                            MessageBox.Show("Record deleted!", "Delete Record");
                            break;
                        case MessageBoxResult.Cancel:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanDeleteWorkerExecute()
        {
            if (Worker == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
