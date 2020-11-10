using ContactsApp;
using System.Windows;
using System.Windows.Forms;

namespace ContactsAppUI.Commands
{
    public class DeleteContactCommand : TypedCommand<MainWindowVM>
    {
        protected override void Execute(MainWindowVM parameter)
        {
            var result = System.Windows.Forms.MessageBox.Show(
                $@"Delete {parameter.SelectedContact.Surname} from contacts?",
                    @"Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result != DialogResult.OK) return;
            parameter.Project.Contacts.Remove(parameter.SelectedContact);
            ProjectManager.SaveToFile(parameter.Project, @"My Documents\");
        }
    }
}
