using ContactsApp;
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
    public class ContactWindowVM : BaseINotifyClass
    {
        /// <summary>
        /// Поле контакта для временного хранения в целях валидации данных.
        /// </summary>
        private Contact _trueContact;

        /// <summary>
        /// Поле контакта для работы в рамках данного окна.
        /// </summary>
        private ContactVM _contact;

        /// <summary>
        /// Команда сохранения контакта.
        /// </summary>
        private RelayCommand _saveContactCommand;

        /// <summary>
        /// Команда отмены редактирования и закрытия окна.
        /// </summary>
        private RelayCommand _cancelCommand;

        /// <summary>
        /// Команда установки полю значения Checked.
        /// </summary>
        private RelayCommand _checkFieldCommand;

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
        public ContactVM Contact
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
        /// <param name="contact">Контакт, полученный из главного окна</param>
        public ContactWindowVM(Contact contact)
        {
            TrueContact = contact;

            try
            {
                Contact = new ContactVM(contact);
                WindowName = $"Edit contact {contact.Surname}";
            }
            catch
            {
                Contact = new ContactVM
                {
                    BirthDate = new DateTime(2000, 1, 1),
                    PhoneNumber = new PhoneNumberVM()
                };
                WindowName = "Add new contact";
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
                        ((Window)obj).DialogResult = false;
                        ((Window)obj).Close();
                    }));
            }
        }

        /// <summary>
        /// Свойство команды установки полю значения Checked.
        /// </summary>
        public RelayCommand CheckFieldCommand
        {
            get
            {
                return _checkFieldCommand ??
                       (_checkFieldCommand = new RelayCommand(obj =>
                       {
                           var fieldName = obj.ToString();
                           Contact.SetChecked(fieldName);
                       }));
            }
        }

        /// <summary>
        /// Метод проверки полей контакта на заполненность.
        /// </summary>
        /// <param name="contact">Контакт</param>
        /// <returns>Заполнены ли все поля контакта</returns>
        private bool IsFullFiled(ContactVM contact)
        {
            return !string.IsNullOrWhiteSpace(contact.Surname) &&
                   !string.IsNullOrWhiteSpace(contact.Name) &&
                   !string.IsNullOrWhiteSpace(contact.PhoneNumber.ToString()) &&
                   contact.PhoneNumber.Number != 0 &&
                   contact.PhoneNumber.Number.ToString()[0] == '7' &&
                   contact.PhoneNumber.Number.ToString().Length == 11 &&
                   !string.IsNullOrWhiteSpace(contact.Email) &&
                   !string.IsNullOrWhiteSpace(contact.VkId);
        }
    }
}
