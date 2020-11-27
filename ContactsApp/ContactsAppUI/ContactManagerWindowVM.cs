using ContactsApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ContactsApp.Annotations;
using System.Runtime.CompilerServices;

namespace ContactsAppUI
{
    public class ContactManagerWindowVM : INotifyPropertyChanged
    {
        private Contact _contact;

        public Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;
            }
        }

        public ContactManagerWindowVM (Contact contact)
        {
            Contact = contact;
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
