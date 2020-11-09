using ContactsApp;
using ContactsAppUI.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppUI
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private Contact _selectedContact;

        public Project Project { get; set; } = new Project();

        public string Birthdays { get; set; }

        public NewContactCommand NewContactCommand { get; }

        public bool RedactingContact { get; set; }

        public MainWindowVM()
        {
            Project = ProjectManager.DeserializeProject(@"My Documents\");

            if (Project.Contacts.Count > 0)
            {
                checkBirthdays();
                SelectedContact = Project.Contacts[0];
            }

            NewContactCommand = new NewContactCommand();
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

        private void checkBirthdays()
        {
            var surnames = new List<string>();

            foreach (var item in Project.Contacts)
            {
                if ((item.BirthDate.Day == DateTime.Today.Day) && (item.BirthDate.Month == DateTime.Today.Month))
                {
                    surnames.Add(item.Surname);
                }
            }

            Birthdays = $"Сегодня день рождения:\n{String.Join(", ", surnames)}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
