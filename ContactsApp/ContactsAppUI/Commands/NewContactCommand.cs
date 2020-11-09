namespace ContactsAppUI.Commands
{
    public class NewContactCommand : TypedCommand<MainWindowVM>
    {
        protected override void Execute(MainWindowVM viewModel)
        {
            viewModel.RedactingContact = false;

            ContactManagerWindow _contactManagerWindow = new ContactManagerWindow();
            _contactManagerWindow.ShowDialog();
        }
    }
}
