using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс контакта.
    /// </summary>
    public class Contact : ICloneable
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
        /// Номер телефона контакта.
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// Свойство фамилии контакта.
        /// Устанавливает значение фамилии с заглавной буквы, если его длина не больше 50 символов.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                if (value.Length < 50)
                {
                    _surname = Char.ToUpper(value[0]) + value.Substring(1);
                }
                else
                {
                    throw new ArgumentException("Длина фамилии не может быть больше 50");
                }
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
                if (value.Length < 50)
                {
                    _name = Char.ToUpper(value[0]) + value.Substring(1);
                }
                else
                {
                    throw new ArgumentException("Длина имени не может быть больше 50");
                }
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
                if (value.Length < 50)
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Длина email не может быть больше 50");
                }
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
                if (value.Length < 15)
                {
                    _vkId = value;
                }
                else
                {
                    throw new ArgumentException("Длина Id не может быть больше 15");
                }
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
                if (value < DateTime.Today && value.Year > 1900)
                {
                    _birthDate = value;
                }
                else
                {
                    throw new ArgumentException("Дата рождения не может быть больше текущей даты и меньше 1900 года");
                }
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
            PhoneNumber phoneNumber = new PhoneNumber{Number = this.PhoneNumber.Number};

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
    }
}
