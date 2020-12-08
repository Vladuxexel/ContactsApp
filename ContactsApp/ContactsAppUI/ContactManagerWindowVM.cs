﻿using ContactsApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ContactsApp.Annotations;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ContactsAppUI
{
    public class ContactManagerWindowVM : INotifyPropertyChanged
    {
        private Contact _contact;

        private RelayCommand _saveContactCommand;

        private RelayCommand _cancelCommand;

        private bool _editMode;

        public string WindowName { get; set; }

        public Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                OnPropertyChanged(nameof(Contact));
            }
        }

        public ContactManagerWindowVM(Contact contact)
        {
            _editMode = (contact.Surname != null);
            WindowName = _editMode ? $"Edit contact {contact.Surname}" : "Add new contact";

            Contact = contact;

            if (!_editMode)
            {
                Contact.BirthDate = new DateTime(2000, 1, 1);
                Contact.PhoneNumber = new PhoneNumber();
            }
        }

        public RelayCommand SaveContactCommand
        {
            get
            {
                return _saveContactCommand ??
                    (_saveContactCommand = new RelayCommand(obj =>
                    {
                        if (_editMode)
                        {
                            MessageBox.Show("Contact has been changed!");
                        }
                        else
                        {
                            ((Window)obj).DialogResult = true;
                            ((Window)obj).Close();
                        }
                    }));
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ??
                    (_cancelCommand = new RelayCommand(obj =>
                    {
                        ((Window)obj).Close();
                    }));
            }
        }

        /// <summary>
        /// Делегат, отслеживающий изменения свойств компонента.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод, обрабатывающий изменение свойств компонента.
        /// </summary>
        /// <param name="propertyName">Имя свойства.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
