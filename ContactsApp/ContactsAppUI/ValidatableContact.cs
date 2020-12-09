using ContactsApp;
using System;
using System.ComponentModel;

namespace ContactsAppUI
{
    /// <summary>
    /// Класс для манипуляций над валидируемым контактом.
    /// </summary>
    public class ValidatableContact : BaseINotifyClass, IDataErrorInfo
    {
        /// <summary>
        /// Фамилия контакта.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя контакта.
        /// </summary>
        private string _name;

        /// <summary>
        /// Дата рождения контакта.
        /// </summary>
        private DateTime _birthDate;

        /// <summary>
        /// Адрес электронной почты контакта.
        /// </summary>
        private string _email;

        /// <summary>
        /// Идентификатор Вконтакте контакта.
        /// </summary>
        private string _vkId;

        /// <summary>
        /// Номер контакта
        /// </summary>
        private ValidatablePhoneNumber _phoneNumber;

        /// <summary>
        /// Свойство ошибки.
        /// </summary>
        public string Error { get; private set; }


        /// <summary>
        /// Номер телефона контакта.
        /// </summary>
        public ValidatablePhoneNumber PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        /// <summary>
        /// Свойство Фамилии контакта.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = char.ToUpper(value[0]) + value.Substring(1);
                OnPropertyChanged(nameof(Surname));
            }
        }

        /// <summary>
        /// Свойство имени контакта.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = char.ToUpper(value[0]) + value.Substring(1);
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Свойство электронной почты контакта.
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        /// <summary>
        /// Свойство идентификатора Вконтакте контакта.
        /// </summary>
        public string VkId
        {
            get => _vkId;
            set
            {
                _vkId = value;
                OnPropertyChanged(nameof(VkId));
            }
        }

        /// <summary>
        /// Свойство даты рождения контакта.
        /// </summary>
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        /// <summary>
        /// Конструктор класса по умолчанию.
        /// </summary>
        public ValidatableContact() { }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="contact">Валидируемый контакт</param>
        public ValidatableContact(Contact contact)
        {
            Surname = contact.Surname;
            Name = contact.Name;
            BirthDate = contact.BirthDate;
            PhoneNumber = new ValidatablePhoneNumber() { Number = contact.PhoneNumber.Number };
            Email = contact.Email;
            VkId = contact.VkId;
        }

        /// <summary>
        /// Реализация IDataErrorInfo
        /// </summary>
        /// <param name="propertyName">Изменяемое свойство</param>
        /// <returns>Ошибка (при наличии)</returns>
        public string this[string propertyName]
        {
            get
            {
                string error = null;

                switch (propertyName)
                {
                    case "Surname":
                        if (string.IsNullOrWhiteSpace(Surname))
                        {
                            error = "Surname is unset";
                        }
                        else if (Surname.Length > 50)
                        {
                            error = "Length of surname can't exceed 50 characters";
                        }
                        break;
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name))
                        {
                            error = "Name is unset";
                        }
                        else if (Name.Length > 50)
                        {
                            error = "Length of name can't exceed 50 characters";
                        }
                        break;
                    case "BirthDate":
                        if (BirthDate >= DateTime.Now)
                        {
                            error = "Birth date can't exceed current date";
                        }
                        else if (BirthDate.Year < 1900)
                        {
                            error = "Birth date can't be less then 1900 year";
                        }
                        break;
                    case "PhoneNumber":
                        if (PhoneNumber == null)
                        {
                            error = "Phone number is unset";
                        }
                        break;
                    case "Email":
                        if (string.IsNullOrWhiteSpace(Email))
                        {
                            error = "Email is unset";
                        }
                        else if (Email.Length > 50)
                        {
                            error = "Length of E-mail can't exceed 50 characters";
                        }
                        break;
                    case "VkId":
                        if (string.IsNullOrWhiteSpace(VkId))
                        {
                            error = "Vk Id is unset";
                        }
                        else if (VkId.Length > 15)
                        {
                            error = "Length of Vk Id can't exceed 50 characters";
                        }
                        break;
                }

                Error = error;
                return error;
            }
        }
    }
}
