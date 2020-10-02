using System;
using System.Windows;
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

            //Сериализация
            //Project proj = new Project { Contacts = { Contact } };
            //ProjectManager.SerializeProject(proj, @"My Documents\");

            //Десериализация
            //var deser = ProjectManager.DeserializeProject(@"My Documents\");
            //MessageBox.Show(deser.ToString());
        }
    }
}
