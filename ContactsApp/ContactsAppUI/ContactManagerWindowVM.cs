﻿using ContactsApp;
using ContactsApp.Annotations;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ContactsAppUI
{
    /// <summary>
    /// Вью-модель окна добавления/редактирования.
    /// </summary>
    public class ContactManagerWindowVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Поле контакта для временного хранения в целях валидации данных.
        /// </summary>
        private Contact _trueContact;

        /// <summary>
        /// Поле контакта для работы в рамках данного окна.
        /// </summary>
        private ValidatableContact _contact;

        /// <summary>
        /// Команда сохранения контакта.
        /// </summary>
        private RelayCommand _saveContactCommand;

        /// <summary>
        /// Команда отмены редактирования и закрытия окна.
        /// </summary>
        private RelayCommand _cancelCommand;

        /// <summary>
        /// Поле определения режима (добавление/редактирование).
        /// </summary>
        private bool _editMode;

        /// <summary>
        /// Свойство названия окна.
        /// </summary>
        public string WindowName { get; set; }

        /// <summary>
        /// Свойство контакта для временного хранения в целях валидации данных.
        /// </summary>
        public Contact TrueContact
        {
            get => _trueContact;
            set
            {
                _trueContact = value;
                OnPropertyChanged(nameof(TrueContact));
            }
        }

        /// <summary>
        /// Свойство контакта для работы в рамках данного окна.
        /// </summary>
        public ValidatableContact Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                OnPropertyChanged(nameof(Contact));
            }
        }

        /// <summary>
        /// Конструктор класса вью-модели окна добавления/редактирования.
        /// </summary>
        /// <param name="contact">Контак, полученный из гравного окна</param>
        public ContactManagerWindowVM(Contact contact)
        {
            _editMode = (contact.Surname != null);
            WindowName = _editMode ? $"Edit contact {contact.Surname}" : "Add new contact";

            TrueContact = contact;

            if (!_editMode)
            {
                Contact = new ValidatableContact
                {
                    BirthDate = new DateTime(2000, 1, 1),
                    PhoneNumber = new ValidatablePhoneNumber()
                };
            }
            else
            {
                Contact = new ValidatableContact(contact);
            }
        }

        /// <summary>
        /// Свойство команды сохранения контакта.
        /// </summary>
        public RelayCommand SaveContactCommand
        {
            get
            {
                return _saveContactCommand ??
                    (_saveContactCommand = new RelayCommand(obj =>
                    {
                        TrueContact.Surname = Contact.Surname;
                        TrueContact.Name = Contact.Name;
                        TrueContact.BirthDate = Contact.BirthDate;
                        TrueContact.PhoneNumber = new PhoneNumber() { Number = Contact.PhoneNumber.Number };
                        TrueContact.Email = Contact.Email;
                        TrueContact.VkId = Contact.VkId;
                        ((Window)obj).DialogResult = true;
                        ((Window)obj).Close();
                    },
                    obj => (Contact.Error == null) && IsFullFiled(Contact)));
            }
        }

        /// <summary>
        /// Команда закрытия окна добавления/редактирования
        /// </summary>
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
        /// Метод проверки полей контакта на заполненность.
        /// </summary>
        /// <param name="contact">Контакт</param>
        /// <returns>Заполнены ли все поля контакта</returns>
        private bool IsFullFiled(ValidatableContact contact)
        {
            return contact.Surname != null &&
                    contact.Name != null &&
                    contact.BirthDate != null &&
                    contact.PhoneNumber != null &&
                    contact.PhoneNumber.Number != 0 &&
                    contact.PhoneNumber.Number.ToString()[0] == '7' &&
                    contact.PhoneNumber.Number.ToString().Length == 11 &&
                    contact.Email != null &&
                    contact.VkId != null;
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
