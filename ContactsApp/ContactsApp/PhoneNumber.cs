using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp.Annotations;

namespace ContactsApp
{
    /// <summary>
    /// Класс номера телефона.
    /// </summary>
    public class PhoneNumber : INotifyPropertyChanged
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
                if (value == 0)
                {
                    throw new ArgumentException("Phone number is unset");
                }
                else
                {
                    if ((value.ToString().Length == 11) && (value.ToString()[0] == '7'))
                    {
                        _number = value;
                        OnPropertyChanged(nameof(Number));
                    }
                    else
                    {
                        throw new ArgumentException("Phone number must begin begin from 7 and it's length must be 11");
                    }
                }
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
