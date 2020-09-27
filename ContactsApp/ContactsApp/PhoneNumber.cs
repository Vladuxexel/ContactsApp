using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс номера телефона.
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Номер телефона.
        /// </summary>
        private long _number;

        /// <summary>
        /// Свойство номера телефона.
        /// Устанавливает значение номера в случае, если оно начинается с цифры 7 и его длина равна 11.
        /// </summary>
        public long Number
        {
            get => _number;
            set
            {
                if((value.ToString().Length == 11)&&(value.ToString()[0]=='7'))
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException("Номер телефона должен начинаться с цифры 7 и быть длиной в 11 символов");
                }
            }
        }
    }
}
