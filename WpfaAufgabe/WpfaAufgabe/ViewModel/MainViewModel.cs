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

        private bool OpenFileCanExecute()
        {
            return true;
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
            initializeModels();
            Title = "TIA Selection Tool - Datei-Viewer" ;           
        }

        private void initializeModels()
        {
           //Models = new List<ItemModel>();
           //ItemModel itemModel_Project = new ItemModel();
           //itemModel_Project.NameItem = "Model";
           //
           //List<PropertyModel> properties_model = new List<PropertyModel>();
           //PropertyModel property_1 = new PropertyModel();
           //property_1.KeyName = "Key Name";
           //property_1.Value = "value";
           //properties_model.Add(property_1);
           //
           //PropertyModel property_2 = new PropertyModel();
           //property_2.KeyName = "Key Name";
           //property_2.Value = "value";
           //properties_model.Add(property_2);
           //
           //itemModel_Project.Properties = properties_model;
           //
           //Properties = itemModel_Project.Properties;
           //
           //ItemModel itemModel_Accesories = new ItemModel();
           //itemModel_Accesories.NameItem = "Accesories";
           //
           //Models.Add(itemModel_Project);
           //Models.Add(itemModel_Accesories);

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
    }
}
