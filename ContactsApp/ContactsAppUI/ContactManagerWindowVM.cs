using ContactsApp;
using ContactsAppUI.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ContactsAppUI
{
    public class ContactManagerWindowVM : INotifyPropertyChanged
    {
        public Contact Contact { get; set; }

        public Project Project { get; set; }

        public bool IsRedacting { get; set; }

        public ContactManagerWindow ContactManagerWindow { get; set; }

        public AddRedactCommand AddRedactCommand { get; }

        public CancelCommand CancelCommand { get; }
        public ContactManagerWindowVM(ContactManagerWindow contactManagerWindow, Contact contact,
                                      Project project, bool isRedacting)
        {
            Contact = contact;
            IsRedacting = isRedacting;
            ContactManagerWindow = contactManagerWindow;
            Project = project;
            AddRedactCommand = new AddRedactCommand();
            CancelCommand = new CancelCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
