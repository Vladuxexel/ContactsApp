using ContactsApp;
using System;
using System.Windows;

namespace ContactsAppUI.Commands
{
    public class AddRedactCommand : TypedCommand<ContactManagerWindowVM>
    {
        protected override bool CanExecute(ContactManagerWindowVM parameter)
        {
            if (parameter.IsRedacting)
            {
                return isFullFilled(parameter) && isChanged(parameter);
            }
            else
            {
                return isFullFilled(parameter);
            }
        }
        protected override void Execute(ContactManagerWindowVM parameter)
        {
            try
            {
                var contact = new Contact()
                {
                    Surname = parameter.ContactManagerWindow.SurnameField.Text,
                    Name = parameter.ContactManagerWindow.NameField.Text,
                    BirthDate = (DateTime)parameter.ContactManagerWindow.BirthDayDataPicker.SelectedDate,
                    PhoneNumber = new PhoneNumber() { Number = Convert.ToInt64(parameter.ContactManagerWindow.PhoneField.Text) },
                    Email = parameter.ContactManagerWindow.EmailField.Text,
                    VkId = parameter.ContactManagerWindow.VkField.Text
                };

                if (parameter.IsRedacting)
                {
                    parameter.Contact.Surname = contact.Surname;
                    parameter.Contact.Name = contact.Name;
                    parameter.Contact.BirthDate = contact.BirthDate;
                    parameter.Contact.PhoneNumber = contact.PhoneNumber;
                    parameter.Contact.Email = contact.Email;
                    parameter.Contact.VkId = contact.VkId;
                }
                else
                {
                    parameter.Project.Contacts.Add(contact);
                }

                ProjectManager.SaveToFile(parameter.Project, ProjectManager.PathFile());
                parameter.ContactManagerWindow.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Error");
            }
        }

        private bool isFullFilled(ContactManagerWindowVM fields)
        {
            if ((fields.ContactManagerWindow.SurnameField.Text != "") &&
               (fields.ContactManagerWindow.NameField.Text != "") &&
               (fields.ContactManagerWindow.BirthDayDataPicker.SelectedDate != null) &&
               (fields.ContactManagerWindow.PhoneField.Text != "") &&
               (fields.ContactManagerWindow.EmailField.Text != "") &&
               (fields.ContactManagerWindow.VkField.Text != ""))
            {
                return true;
            }

            return false;
        }

        private bool isChanged(ContactManagerWindowVM form)
        {
            if ((form.Contact.Surname != form.ContactManagerWindow.SurnameField.Text) ||
                (form.Contact.Name != form.ContactManagerWindow.NameField.Text) ||
                (form.Contact.BirthDate != (DateTime)form.ContactManagerWindow.BirthDayDataPicker.SelectedDate) ||
                (form.Contact.PhoneNumber.Number != Convert.ToInt64(form.ContactManagerWindow.PhoneField.Text)) ||
                (form.Contact.Email != form.ContactManagerWindow.EmailField.Text) ||
                (form.Contact.VkId != form.ContactManagerWindow.VkField.Text))
            {
                return true;
            }

            return false;
        }
    }
}
