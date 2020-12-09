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
    /// <summary>
    /// Вью-модель главного окна.
    /// </summary>
    public class MainWindowVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Поле выбранного контакта.
        /// </summary>
        private Contact _selectedContact;

        /// <summary>
        /// Команда редактирования контакта.
        /// </summary>
        private RelayCommand _editContactCommand;

        /// <summary>
        /// Команда добавления контакта.
        /// </summary>
        private RelayCommand _addContactCommand;

        /// <summary>
        /// Команда удаления контакта.
        /// </summary>
        private RelayCommand _deleteContactCommand;

        /// <summary>
        /// Команда закрытия главного окна приложенияю
        /// </summary>
        private RelayCommand _exitApplicationCommand;

        /// <summary>
        /// Команда открытия окна "About"
        /// </summary>
        private RelayCommand _showAboutCommand;

        /// <summary>
        /// Автосвойство проекта.
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// Свойство выбранного контакта.
        /// </summary>
        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        /// <summary>
        /// Конструктор вью-модели главного окна.
        /// </summary>
        public MainWindowVM()
        {
            Project = ProjectManager.LoadFromFile(ProjectManager.PathFile());
            if (Project.Contacts.Count > 0)
            {
                SelectedContact = Project.Contacts.First();
            }
        }

        /// <summary>
        /// Свойство команды редактирования контакта.
        /// </summary>
        public RelayCommand EditContactCommand
        {
            get
            {
                return _editContactCommand ??
                    (_editContactCommand = new RelayCommand(obj =>
                    {
                        var contactWindow = new ContactManagerWindow(SelectedContact.Clone() as Contact);
                        contactWindow.ShowDialog();
                        if (contactWindow.DialogResult == true)
                        {
                            SelectedContact.Surname = contactWindow.Contact.Surname;
                            SelectedContact.Name = contactWindow.Contact.Name;
                            SelectedContact.BirthDate = contactWindow.Contact.BirthDate;
                            SelectedContact.PhoneNumber = contactWindow.Contact.PhoneNumber;
                            SelectedContact.Email = contactWindow.Contact.Email;
                            SelectedContact.VkId = contactWindow.Contact.VkId;
                            ProjectManager.SaveToFile(Project, ProjectManager.PathFile());
                        }
                    }));
            }
        }

        /// <summary>
        /// Свойство команды добавления контакта.
        /// </summary>
        public RelayCommand AddContactCommand
        {
            get
            {
                return _addContactCommand ??
                    (_addContactCommand = new RelayCommand(obj =>
                    {
                        var contactWindow = new ContactManagerWindow(new Contact());
                        contactWindow.ShowDialog();
                        if (contactWindow.DialogResult == true)
                        {
                            Project.Contacts.Add(contactWindow.Contact);
                            ProjectManager.SaveToFile(Project, ProjectManager.PathFile());
                        }
                    }));
            }
        }

        /// <summary>
        /// Свойство команды удаления контакта.
        /// </summary>
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

        /// <summary>
        /// Свойство команды закрытия главного окна.
        /// </summary>
        public RelayCommand ExitApplicationCommand
        {
            get
            {
                return _exitApplicationCommand ??
                    (_exitApplicationCommand = new RelayCommand(obj =>
                    {
                        ((Window)obj).Close();
                    }));
            }
        }

        /// <summary>
        /// Свойство команды открытия окна About.
        /// </summary>
        public RelayCommand ShowAboutCommand
        {
            get
            {
                return _showAboutCommand ??
                    (_showAboutCommand = new RelayCommand(obj =>
                    {
                        var aboutWindow = new AboutWindow();
                        aboutWindow.ShowDialog();
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
