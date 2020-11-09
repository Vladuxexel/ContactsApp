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

            //Сериализация
            //Project proj = new Project { Contacts = { Contact } };
            //ProjectManager.SerializeProject(proj, @"My Documents\");

            //Десериализация
            //var deser = ProjectManager.DeserializeProject(@"My Documents\");
            //MessageBox.Show(deser.ToString());
        }
    }
}
