using ContactsApp;
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
        private Contact _trueContact;

        private ValidatableContact _contact;

        private RelayCommand _saveContactCommand;

        private RelayCommand _cancelCommand;

        private bool _editMode;

        public string WindowName { get; set; }

        public Contact TrueContact
        {
            get => _trueContact;
            set
            {
                _trueContact = value;
                OnPropertyChanged(nameof(TrueContact));
            }
        }

        public ValidatableContact Contact
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
