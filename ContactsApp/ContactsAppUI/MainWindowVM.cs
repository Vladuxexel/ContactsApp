using ContactsApp;
using System;
using System.Collections.Generic;
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

        private RelayCommand _editContactCommand;

        private RelayCommand _addContactCommand;

        private RelayCommand _deleteContactCommand;

        public Project Project { get; set; }

        public ContactManagerWindow ContactWindow { get; set; }

        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public MainWindowVM()
        {
            Project = ProjectManager.LoadFromFile(ProjectManager.PathFile());
            SelectedContact = Project.Contacts.First();
        }

        public RelayCommand EditContactCommand
        {
            get
            {
                return _editContactCommand ??
                    (_editContactCommand = new RelayCommand(obj =>
                    {
                        ContactWindow = new ContactManagerWindow(SelectedContact.Clone() as Contact);
                        ContactWindow.ShowDialog();
                    }));
            }
        }

        public RelayCommand AddContactCommand
        {
            get
            {
                return _addContactCommand ??
                    (_addContactCommand = new RelayCommand(obj =>
                    {
                        ContactWindow = new ContactManagerWindow(new Contact());
                        ContactWindow.ShowDialog();
                        if (ContactWindow.DialogResult == true)
                        {
                            Project.Contacts.Add(ProjectManager.TempContact);
                        }
                    }));
            }
        }

        public RelayCommand DeleteContactCommand
        {
            get
            {
                return _deleteContactCommand ??
                    (_deleteContactCommand = new RelayCommand(obj =>
                    {
                        if (MessageBox.Show($"Are you sure you want to delete {SelectedContact.Surname} ?",
                            "Delete confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            Project.Contacts.Remove(SelectedContact);
                            SelectedContact = Project.Contacts.First();
                            ProjectManager.SaveToFile(Project, ProjectManager.PathFile());
                        }
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
