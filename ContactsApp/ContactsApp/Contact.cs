using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp.Annotations;

namespace ContactsApp
{
    /// <summary>
    /// Класс контакта.
    /// </summary>
    public class Contact : ICloneable, INotifyPropertyChanged
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
        private PhoneNumber _phoneNumber;

        /// <summary>
        /// Номер телефона контакта.
        /// </summary>
        public PhoneNumber PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value ?? throw new ArgumentException("Phone number is unset");
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        /// <summary>
        /// Свойство фамилии контакта.
        /// Устанавливает значение фамилии с заглавной буквы, если его длина не больше 50 символов.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Surname is unset");

                if (value.Length > 50) throw new ArgumentException("Length of surname can't exceed 50 characters");

                _surname = char.ToUpper(value[0]) + value.Substring(1);
                OnPropertyChanged(nameof(Surname));
            }
        }

        /// <summary>
        /// Свойство имени контакта.
        /// Устанавливает значение имени с заглавной буквы, если его длина не больше 50 символов.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name is unset");

                if (value.Length > 50) throw new ArgumentException("Length of name can't exceed 50 characters");

                _name = char.ToUpper(value[0]) + value.Substring(1);
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Свойство электронной почты контакта.
        /// Устанавливает значение электронной почты, если его длина не больше 50 символов.
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("E-mail is unset");

                if (value.Length > 50) throw new ArgumentException("Length of E-mail can't exceed 50 characters");

                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        /// <summary>
        /// Свойство идентификатора Вконтакте контакта.
        /// Устанавливает значение идентификатора Вконтакте, если его длина не больше 15 символов.
        /// </summary>
        public string VkId
        {
            get => _vkId;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Vk Id is unset");

                if (value.Length > 15) throw new ArgumentException("Length of Vk Id can't exceed 15 characters");

                _vkId = value;
                OnPropertyChanged(nameof(VkId));
            }
        }

        /// <summary>
        /// Свойство даты рождения контакта.
        /// Устанавливает значение даты рождения контакта, если оно меньше текущей даты и его год болше 1900.
        /// </summary>
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                if (value >= DateTime.Today) throw new ArgumentException("Birth date can't exceed current date");

                if (value.Year < 1900) throw new ArgumentException("Birth date can't be less then 1900 year");

                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        /// <summary>
        /// Метод клонирования объекта данного класса.
        /// </summary>
        /// <returns>
        /// Возвращает копию объекта данного класса.
        /// </returns>
        public object Clone()
        {
            var phoneNumber = new PhoneNumber { Number = this.PhoneNumber.Number };

            return new Contact
            {
                PhoneNumber = phoneNumber,
                Surname = this.Surname,
                Name = this.Name,
                Email = this.Email,
                VkId = this.VkId,
                BirthDate = this.BirthDate
            };
        }

        /// <summary>
        /// Метод, проверяющий, не привышает ли длина входного параметра установленное ограничение.
        /// </summary>
        /// <param name="parameter">Входной параметр строкового значения.</param>
        /// <param name="target">Установленное ограничение на длину параметра.</param>
        /// <returns></returns>
        private bool IsLonger(int parameterLength, int target)
        {
            return parameterLength > target;
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
