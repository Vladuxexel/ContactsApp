using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContactsApp;

namespace ContactsAppUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var Contact = new Contact();
            Contact.Surname = textBox.Text;
            Contact.Name = textBox_Copy.Text;
            Contact.BirthDate = datePicker.DisplayDate;
            Contact.PhoneNumber = new PhoneNumber {Number = Convert.ToInt64(textBox_Copy2.Text)};
            Contact.Email = textBox_Copy3.Text;
            Contact.VkId = textBox_Copy4.Text;

            MessageBox.Show(Contact.ToString());
        }
    }
}
