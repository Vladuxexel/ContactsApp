using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс логики проекта.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Динамическая коллекция контактов проекта.
        /// </summary>
        public ObservableCollection<Contact> ContactsList = new ObservableCollection<Contact>();
    }
}
