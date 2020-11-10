namespace ContactsAppUI.Commands
{
    public class NewContactCommand : TypedCommand<MainWindowVM>
    {
        protected override void Execute(MainWindowVM parameter)
        {
            ContactManagerWindow _contactManagerWindow = new ContactManagerWindow(parameter.Project, 
                                                                                  parameter.SelectedContact,
                                                                                  parameter.Birthdays, false);
            _contactManagerWindow.SurnameField.Text = "";
            _contactManagerWindow.NameField.Text = "";
            _contactManagerWindow.BirthDayDataPicker.SelectedDate = null;
            _contactManagerWindow.PhoneField.Text = "";
            _contactManagerWindow.EmailField.Text = "";
            _contactManagerWindow.VkField.Text = "";
            _contactManagerWindow.ShowDialog();
        }
    }
}
