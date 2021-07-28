using System;
using System.Collections.Generic;
using System.Windows.Input;
using WpfaAufgabe.Commo;
using WpfaAufgabe.Core;
using WpfaAufgabe.Model;

namespace WpfaAufgabe.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private List<ItemModel> _models;
        private string _title;
        private List<PropertyModel> _properties;
        private ICommand _openFileCommand;
        private string _fileName="";
        public ICommand OpenFileCommand
        {
            get {
                if (_openFileCommand == null)
                {
                    _openFileCommand = new Command(action => OpenFileExecute(),predicate => OpenFileCanExecute());
                }
                return _openFileCommand;
            }
        }

        private ICommand _loadItemPropertiesCommand;
        public ICommand LoadItemPropertiesCommand
        {
            get
            {
                if (_loadItemPropertiesCommand == null)
                {
                    _loadItemPropertiesCommand = new Command(action => LoadItemsExecute(action), predicate => LoadItemCanExecute());
                }

                return _loadItemPropertiesCommand;
            }
        }
        
        public List<PropertyModel> Properties
        {
            get { return _properties; }
            set { _properties = value;
                OnPropertyChanged(nameof(Properties));
            }
        }

        public List<ItemModel> Models
        {
            get { return _models; }
            set { _models = value;
                OnPropertyChanged(nameof(Models));
            }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        
        public MainViewModel()
        {
            Title = "TIA Selection Tool - Datei-Viewer" ;           
        }

       private void OpenFileExecute()
       {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.Filter = "Tia files (*.tia)|*.tia";
            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();

            // Get the selected file name and display in a TextBox.
            // Load content of file in the itemcontrol
            if (result == true)
            {
                 _fileName = openFileDlg.FileName;
                Title += _fileName;
                Models = TiaFileConverter.GetModels(_fileName);   
            }
        }
        
        private bool OpenFileCanExecute()
        {
            return true;
        }
        
        private void LoadItemsExecute(object parameters)
        {
            var NameItem = (string)parameters;
            if (NameItem!=null)
            {
               Properties = TiaFileConverter.GetProperties(NameItem);
            }

        }

        private bool LoadItemCanExecute()
        {
            if (_fileName !=null)
            {
                return true;
            }
            return false;
        }
    }
}
