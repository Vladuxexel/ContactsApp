using ContactsApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactsAppUI
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private Contact _selectedContact;

        public Project Project { get; set; } = new Project();

        public MainWindowVM()
        {
            Project = ProjectManager.DeserializeProject(@"My Documents\");
        }

        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
