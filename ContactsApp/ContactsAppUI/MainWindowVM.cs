using ContactsApp;
using ContactsAppUI.Commands;
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

        private string _birthDays;

        public Project Project { get; set; } = new Project();

        public Visibility Visibility { get; set; } = Visibility.Hidden;

        public NewContactCommand NewContactCommand { get; }
        public RedactContactCommand RedactContactCommand { get; }
        public DeleteContactCommand DeleteContactCommand { get; }
        public AboutCommand AboutCommand { get; }

        public MainWindowVM()
        {
            Project = ProjectManager.LoadFromFile(ProjectManager.PathFile());

            if (Project.Contacts.Count > 0)
            {
                checkBirthdays();
                SelectedContact = Project.Contacts[0];
            }

            NewContactCommand = new NewContactCommand();
            RedactContactCommand = new RedactContactCommand();
            DeleteContactCommand = new DeleteContactCommand();
            AboutCommand = new AboutCommand();
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

        public string Birthdays
        {
            get => _birthDays;
            set
            {
                _birthDays = value;
                OnPropertyChanged(nameof(Birthdays));
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

            if(surnames.Count > 0)
            {
                Visibility = Visibility.Visible;
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
