using System.Collections.ObjectModel;

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
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
    }
}
